using OOP1;

Product product = new Product()
{
    Id = 1,
    CategoryId = 2,
    ProductName = "Masa",
    UnitPrice = 5000,
    UnitsInStock = 5
};

Product product1 = new Product() 
{ Id = 2, CategoryId = 3, UnitPrice = 400, UnitsInStock = 5, ProductName = "Lamba" };

//PascalCase - camelCase

ProductManager productManager = new ProductManager();
productManager.Add(product);
productManager.Update(product,2000);
productManager.Delete(product);