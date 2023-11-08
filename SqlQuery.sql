--SQL SORGULARI (85)
---------------------------------
--26. Stokta bulunmayan ürünlerin ürün listesiyle birlikte tedarikçilerin ismi ve iletişim numarasını 
-- (`ProductID`, `ProductName`, `CompanyName`, `Phone`) almak için bir sorgu yazın.
select p.product_id, p.product_name, s.company_name, s.phone, p.units_in_stock
from products p 
join suppliers s on p.supplier_id = s.supplier_id
where units_in_stock=0

-- 27. 1998 yılı mart ayındaki siparişlerimin adresi, siparişi alan çalışanın adı, çalışanın soyadı
select o.order_date, c.address, e.first_name, e.last_name
from orders o
join customers c on o.customer_id=c.customer_id 
join employees e on o.employee_id=e.employee_id
where EXTRACT(YEAR FROM order_date) = 1998 AND EXTRACT(MONTH FROM order_date) = 3

-- 28. 1997 yılı şubat ayında kaç siparişim var?
select count(*) from orders 
WHERE EXTRACT(YEAR FROM order_date) = 1997 AND EXTRACT(MONTH FROM order_date) = 2

--29. London şehrinden 1998 yılında kaç siparişim var?
select count(*) from orders 
WHERE EXTRACT(YEAR FROM order_date) = 1998 AND ship_city = 'London'

-- 30. 1997 yılında sipariş veren müşterilerimin contactname ve telefon numarası
--1.Yöntem
SELECT DISTINCT ON (c.customer_id)  c.contact_name, c.phone, o.order_date
FROM Orders o
JOIN customers c on o.customer_id = c.customer_id
WHERE EXTRACT(YEAR FROM order_date) = 1997

--2.Yöntem
SELECT c.contact_name, c.phone
FROM customers c
WHERE c.customer_id IN (
    SELECT DISTINCT o.customer_id
    FROM orders o
    WHERE EXTRACT(YEAR FROM order_date) = 1997)

--31. Taşıma ücreti 40 üzeri olan siparişlerim?
SELECT *
FROM orders
WHERE freight > 40
Order By freight

--32. Taşıma ücreti 40 ve üzeri olan siparişlerimin şehri, müşterisinin adı?
SELECT c.company_name, c.city,o.freight
FROM Orders o
     JOIN customers c on o.customer_id=c.customer_id
WHERE freight >= 40
Order By freight

--33. 1997 yılında verilen siparişlerin tarihi, şehri, çalışan adı -soyadı ( ad soyad birleşik olacak ve büyük harf)
SELECT CONCAT (upper(e.first_name), ' ', upper(e.last_name)),e.city,o.order_Date
FROM orders o
     JOIN employees e ON o.employee_id= e.employee_id
WHERE Extract(YEAR FROM order_Date)=1997

--34. 1997 yılında sipariş veren müşterilerin contactname i, ve telefon numaraları ( telefon formatı 2223322 gibi olmalı )
Select Distinct c.contact_Name, Replace(Replace(REPLACE(REPLACE(REPLACE(c.Phone, '(', ''), ')', ''), ' ', ''),'-', ''), '.', '') 
as Phone
from Customers c
Inner join Orders o on c.Customer_Id = o.Customer_Id
Where Extract(YEAR FROM o.Order_Date) = 1997

--35. Sipariş tarihi, müşteri contact name, çalışan ad, çalışan soyad
SELECT e.first_name, e.last_name, c.contact_name, o.order_date
FROM Orders o
     JOIN customers c on o.customer_id = c.customer_id
	 JOIN employees e on o.employee_id = e.employee_id

--36. Geciken siparişlerim?
SELECT *
FROM orders
where required_date < shipped_date OR shipped_date is null

--37. Geciken siparişlerimin tarihi, müşterisinin adı
SELECT c.company_name, o.order_date
FROM orders o
    JOIN customers c on o.customer_id = c.customer_id
where required_date < shipped_date OR shipped_date is null

--38. 10248 nolu siparişte satılan ürünlerin adı, kategorisinin adı, adedi
select od.order_id,p.product_name , c.category_name, od.quantity
from order_details od
     JOIN products p on od.product_id = p.product_id
	 JOIN categories c on p.category_id=c.category_id
where order_id = 10248

--39. 10248 nolu siparişin ürünlerinin adı , tedarikçi adı
select od.order_id,p.product_name , s.company_name
from order_details od
     JOIN products p on od.product_id = p.product_id
	 JOIN suppliers s on p.supplier_id = s.supplier_id
where order_id = 10248

--40. 3 numaralı ID ye sahip çalışanın 1997 yılında sattığı ürünlerin adı ve adeti
select p.product_name, od.quantity
from products p
     JOIN order_details od on od.product_id = p.product_id -- Quantity
	 JOIN orders o on o.order_id = od.order_id --order_Date
     JOIN employees e on e.employee_id = o.employee_id --emlpoyee_id
Where e.employee_id = 3 AND Extract(year from o.order_date)=1997

--41. 1997 yılında bir defasinda en çok satış yapan çalışanımın ID,Ad soyad
SELECT  o.order_id,e.employee_id ,e.first_name,e.last_name,SUM(od.quantity) as total
FROM orders o
     JOIN employees e on o.employee_id = e.employee_id
	 JOIN order_details od on od.order_id = o.order_id
WHERE Extract(year from o.order_date)=1997 
Group By o.order_id,e.employee_id,e.first_name,e.last_name
Order by SUM(od.quantity) desc
limit 1 

--42. 1997 yılında en çok satış yapan çalışanımın ID,Ad soyad ****
SELECT  e.employee_id ,e.first_name,e.last_name,SUM(od.quantity) as total
FROM orders o
     JOIN employees e on o.employee_id = e.employee_id
	 JOIN order_details od on od.order_id = o.order_id
WHERE Extract(year from o.order_date)=1997 
Group By e.employee_id,e.first_name,e.last_name
Order by SUM(od.quantity) desc
limit 1 

--43. En pahalı ürünümün adı,fiyatı ve kategorisin adı nedir?
select p.product_name, p.unit_price, c.category_name
from Products P
     JOIN categories c on p.category_id =c.category_id
order by p.unit_price desc
limit 1

--44. Siparişi alan personelin adı,soyadı, sipariş tarihi, sipariş ID. Sıralama sipariş tarihine göre
SELECT e.first_name, e.last_name, o.order_date, o.order_id
FROM Employees e
     JOIN Orders o on e.employee_id = o.employee_id
Order by o.order_date 

--45. SON 5 siparişimin ortalama fiyatı ve orderid nedir?
SELECT OD.Order_ID, avg((P.Unit_Price * OD.Quantity) - (P.Unit_Price * OD.Quantity) * OD.Discount) AS TotalPrice
FROM Order_Details OD
     JOIN Products P ON OD.Product_ID = P.Product_ID
GROUP BY OD.Order_ID
ORDER BY OD.Order_ID DESC
limit 5

--46. Ocak ayında satılan ürünlerimin adı ve kategorisinin adı ve toplam satış miktarı nedir?
SELECT  p.product_name , c.category_name, SUM(od.quantity) AS "TOPLAM_ADET", o.order_Date AS OCAK
FROM products p
     JOIN categories c on p.category_id = c.category_id
	 JOIN order_details od on p.product_id = od.product_id
	 JOIN orders o on od.order_id = o.order_id
WHERE EXTRACT(MONTH FROM order_date) = 1
Group By p.product_name , c.category_name,o.order_Date 
ORDER BY SUM(od.quantity)

--47. Ortalama satış miktarımın üzerindeki satışlarım nelerdir?
SELECT order_id,quantity AS TOPLAM_ADET
FROM ORDER_DETAILS
WHERE quantity>(SELECT AVG(quantity) FROM ORDER_DETAILS) --23.812
ORDER BY quantity 

--48. En çok satılan ürünümün(adet bazında) adı, kategorisinin adı ve tedarikçisinin adı
SELECT p.product_name,c.category_name,s.company_name,SUM(od.quantity) AS ADET
FROM products p
     JOIN Categories c on p.category_id = c.category_id
	 JOIN Suppliers s on p.supplier_id = s.supplier_id
	 JOIN Order_details od on p.product_id = od.product_id
GROUP BY p.product_name,c.category_name,s.company_name
ORDER BY ADET DESC
limit 1

--49. Kaç ülkeden müşterim var
SELECT COUNT(Distinct country) AS "TEKİL ÜLKE SAYISI"
FROM CUSTOMERS

--50. 3 numaralı ID ye sahip çalışan (employee) son Ocak ayından BUGÜNE toplamda ne kadarlık ürün sattı?
SELECT e.employee_id ,e.first_name,e.last_name,SUM(od.quantity*od.unit_price) AS TOPLAM
FROM Employees e
    JOIN Orders o on e.employee_id = o.employee_id
	JOIN Order_Details od on o.order_id = od.order_id
WHERE e.employee_id = 3 AND   o.order_date between '1998-01-01' AND  CURRENT_DATE           
GROUP BY  e.employee_id ,e.first_name,e.last_name

--51. 10248 nolu siparişte satılan ürünlerin adı, kategorisinin adı, adedi
SELECT od.order_id,p.product_name , c.category_name, od.quantity
FROM order_details od
     JOIN products p on od.product_id = p.product_id
	 JOIN categories c on p.category_id=c.category_id
WHERE order_id = 10248

--52. 10248 nolu siparişin ürünlerinin adı , tedarikçi adı
SELECT p.product_name , s.company_name,od.order_id
From order_details od
     JOIN Products p on od.product_id = p.product_id
	 JOIN Suppliers s on p.supplier_id = s.supplier_id
WHERE order_id = 10248

--53. 3 numaralı ID ye sahip çalışanın 1997 yılında sattığı ürünlerin adı ve adeti
SELECT e.employee_id,p.product_name,od.quantity,o.order_date
FROM products p
     JOIN order_details od on od.product_id = p.product_id 
	 JOIN orders o on o.order_id = od.order_id 
     JOIN employees e on e.employee_id = o.employee_id -
WHERE e.employee_id=3 AND Extract(YEAR FROM o.order_date)=1997

--54. 1997 yılında bir defasinda en çok satış yapan çalışanımın ID,Ad soyad
SELECT  o.order_id,e.employee_id ,e.first_name,e.last_name,SUM(od.quantity) as TOTAL
FROM orders o
     JOIN employees e on o.employee_id = e.employee_id
	 JOIN order_details od on od.order_id = o.order_id
WHERE Extract(year from o.order_date)=1997 
Group By o.order_id,e.employee_id,e.first_name,e.last_name
Order by SUM(od.quantity) desc
limit 1 

--55. 1997 yılında en çok satış yapan çalışanımın ID,Ad soyad ****
SELECT  e.employee_id ,e.first_name,e.last_name,SUM(od.quantity) as TOTAL
FROM orders o
     JOIN employees e on o.employee_id = e.employee_id
	 JOIN order_details od on od.order_id = o.order_id
WHERE Extract(year from o.order_date)=1997 
Group By e.employee_id,e.first_name,e.last_name
Order by SUM(od.quantity) desc
limit 1 

--56. En pahalı ürünümün adı,fiyatı ve kategorisin adı nedir?
SELECT p.product_name, p.unit_price, c.category_name
FROM Products P
     JOIN categories c on p.category_id =c.category_id
ORDER BY p.unit_price desc
limit 1

--57. Siparişi alan personelin adı,soyadı, sipariş tarihi, sipariş ID. Sıralama sipariş tarihine göre
SELECT e.first_name, e.last_name, o.order_date, o.order_id
FROM Employees e
     JOIN Orders o on e.employee_id = o.employee_id
ORDER BY o.order_date 

--58. SON 5 siparişimin ortalama fiyatı ve orderid nedir?
SELECT OD.Order_ID, avg((P.Unit_Price * OD.Quantity) - (P.Unit_Price * OD.Quantity) * OD.Discount) AS TotalPrice
FROM Order_Details OD
     JOIN Products P ON OD.Product_ID = P.Product_ID
GROUP BY OD.Order_ID
ORDER BY OD.Order_ID DESC
limit 5

--59. Ocak ayında satılan ürünlerimin adı ve kategorisinin adı ve toplam satış miktarı nedir?
SELECT  p.product_name , c.category_name, SUM(od.quantity) AS "TOPLAM_ADET", o.order_Date AS OCAK
FROM products p
     JOIN categories c on p.category_id = c.category_id
	 JOIN order_details od on p.product_id = od.product_id
	 JOIN orders o on od.order_id = o.order_id
WHERE EXTRACT(MONTH FROM order_date) = 1
Group By p.product_name , c.category_name,o.order_Date 
ORDER BY SUM(od.quantity)

--60. Ortalama satış miktarımın üzerindeki satışlarım nelerdir?
SELECT quantity AS ADET
FROM ORDER_DETAILS
WHERE quantity>(SELECT AVG(quantity) FROM ORDER_DETAILS) --23.812
ORDER BY quantity

--61. En çok satılan ürünümün(adet bazında) adı, kategorisinin adı ve tedarikçisinin adı
SELECT p.product_name,c.category_name,s.company_name,SUM(od.quantity) AS ADET
FROM products p
     JOIN Categories c on p.category_id = c.category_id
	 JOIN Suppliers s on p.supplier_id = s.supplier_id
	 JOIN Order_details od on p.product_id = od.product_id
GROUP BY p.product_name,c.category_name,s.company_name
ORDER BY ADET DESC
limit 1

--62. Kaç ülkeden müşterim var
SELECT COUNT(Distinct country) AS "TEKİL ÜLKE SAYISI"
FROM CUSTOMERS

--63. Hangi ülkeden kaç müşterimiz var
SELECT DISTINCT ON(Country) country,COUNT(Customer_id) AS "NumberOfCustomers"
FROM Customers
GROUP BY Country

--64. 3 numaralı ID ye sahip çalışan (employee) son Ocak ayından BUGÜNE toplamda ne kadarlık ürün sattı?
SELECT e.employee_id ,e.first_name,e.last_name,SUM(od.quantity*od.unit_price) AS TOPLAM
FROM Employees e
    JOIN Orders o on e.employee_id = o.employee_id
	JOIN Order_Details od on o.order_id = od.order_id
WHERE e.employee_id = 3 AND   o.order_date between '1998-01-01' AND  CURRENT_DATE           
GROUP BY  e.employee_id ,e.first_name,e.last_name

--65. 10 numaralı ID ye sahip ürünümden son 3 ayda ne kadarlık ciro sağladım?
SELECT p.product_id,SUM((od.unit_price - (od.unit_price*od.discount/100)) * od.quantity ) AS TOPLAM_CIRO
FROM PRODUCTS p
     JOIN order_Details od on p.product_id = od.product_id
	 JOIN Orders o on od.order_id = o.order_id
WHERE p.product_id = 10 AND o.order_date >= '1998-05-06'::date - INTERVAL '3 months'
                       AND o.order_Date <= '1998-05-06'::date					   
GROUP BY p.product_id

--66. Hangi çalışan şimdiye kadar toplam kaç sipariş almış..?
SELECT CONCAT(e.first_name,' ',e.last_name) AS "ADI-SOYADI",SUM(od.quantity) AS "ALINAN SİPARİŞ ADEDİ"
FROM Orders o
     JOIN Employees e on o.employee_id = e.employee_id
	 JOIN order_details od on o.order_id = od.order_id
GROUP BY CONCAT(e.first_name,' ',e.last_name)
ORDER BY CONCAT(e.first_name,' ',e.last_name)

--67. 91 müşterim var. Sadece 89’u sipariş vermiş. Sipariş vermeyen 2 kişiyi bulun
SELECT c.customer_id,c.company_name,o.order_id
FROM customers c
     LEFT JOIN ORDERS o on c.customer_id = o.customer_id
WHERE o.order_id IS NULL

--68. Brazil’de bulunan müşterilerin Şirket Adı, TemsilciAdi, Adres, Şehir, Ülke bilgileri
SELECT c.company_name, c.contact_name,c.address,c.city,c.country
FROM CUSTOMERS c
WHERE c.country = 'Brazil'

--69. Brezilya’da olmayan müşteriler
SELECT c.company_name, c.contact_name,c.address,c.city,c.country
FROM CUSTOMERS c
WHERE c.country != 'Brazil'

--70. Ülkesi (Country) YA Spain, Ya France, Ya da Germany olan müşteriler
SELECT c.customer_id,c.country,c.company_name
FROM CUSTOMERS c
WHERE c.country IN ('Spain','France','Germany')

--71. Faks numarasını bilmediğim müşteriler
SELECT c.customer_id,c.company_name,c.FAX
FROM CUSTOMERS c
WHERE c.fax IS NULL

--72. Londra’da ya da Paris’de bulunan müşterilerim
SELECT c.customer_id,c.company_name,c.city
FROM CUSTOMERS c
WHERE c.city IN ('London','Paris')

--73. Hem Mexico D.F’da ikamet eden HEM DE ContactTitle bilgisi ‘owner’ olan müşteriler
SELECT *
FROM CUSTOMERS c
WHERE c.city = 'México D.F.' AND c.contact_title = 'Owner'

--74. C ile başlayan ürünlerimin isimleri ve fiyatları
SELECT p.product_name, p.unit_price
FROM PRODUCTS p
WHERE p.product_name LIKE 'C%'

--75. Adı (FirstName) ‘A’ harfiyle başlayan çalışanların (Employees); Ad, Soyad ve Doğum Tarihleri
SELECT e.first_name,e.last_name,e.birth_Date
FROM Employees e
WHERE e.first_name LIKE 'A%' 

--76. İsminde ‘RESTAURANT’ geçen müşterilerimin şirket adları
SELECT c.company_name
FROM CUSTOMERS c
WHERE UPPER(c.company_name) LIKE '%RESTAURANT%'

--77. 50$ ile 100$ arasında bulunan tüm ürünlerin adları ve fiyatları
SELECT p.product_name,p.unit_price
FROM PRODUCTS p
WHERE p.unit_price > 50 AND  p.unit_price < 100
ORDER BY p.unit_price

--78. 1 temmuz 1996 ile 31 Aralık 1996 tarihleri arasındaki siparişlerin (Orders), SiparişID (OrderID) ve SiparişTarihi (OrderDate) bilgileri
SELECT o.order_id,o.order_Date
FROM ORDERS o
WHERE o.order_date >= '1996-07-01' AND  o.order_date <= '1996-12-31'
ORDER BY o.order_Date

--79. Ülkesi (Country) YA Spain, Ya France, Ya da Germany olan müşteriler
SELECT c.customer_id ,c.country
FROM CUSTOMERS c
WHERE c.country IN ('Spain','France','Germany')

--80. Faks numarasını bilmediğim müşteriler
SELECT c.customer_id,c.fax
FROM CUSTOMERS c
WHERE c.fax IS NULL

--81. Müşterilerimi ülkeye göre sıralıyorum:
SELECT c.country,c.customer_id,c.company_name
FROM customers c
ORDER BY c.country

--82. Ürünlerimi en pahalıdan en ucuza doğru sıralama, sonuç olarak ürün adı ve fiyatını istiyoruz
SELECT p.product_name,p.unit_price
FROM Products p
ORDER BY p.unit_price desc

--83. Ürünlerimi en pahalıdan en ucuza doğru sıralasın, ama stoklarını küçükten-büyüğe doğru göstersin sonuç olarak ürün adı ve fiyatını istiyoruz
SELECT p.product_name,p.unit_price,p.units_in_stock
FROM Products p
ORDER BY p.unit_price desc , p.units_in_stock

--84. 1 Numaralı kategoride kaç ürün vardır..?
SELECT COUNT(*)
FROM Products p 
     JOIN Categories c on p.category_id = c.category_id
WHERE c.category_id = 1

--85. Kaç farklı ülkeye ihracat yapıyorum..?
SELECT COUNT( DISTINCT ship_country) AS "IHRACAT YAPILAN ULKE SAYISI"
FROM orders

---FINISHED---


