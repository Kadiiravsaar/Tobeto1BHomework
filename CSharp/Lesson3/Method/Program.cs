using OOP.Lesson._3;

Product prod1 = new Product()
{
    Id = 1,
    Name = "Elma",
    Price = 15,
    Description = "Amasya elması"
};

Product prod2 = new Product()
{
    Id = 2,
    Name = "Karpuz",
    Price = 80,
    Description = "Diyarbakır karpuzu"
};

Product[] products = new Product[] { prod1, prod2 };

foreach (Product product in products) // type safe => tip güvenli. Çalışacağımı bilmek isterim o yüzden Urun urun in urunler dedim
{
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Description);
    Console.WriteLine(product.Price);
    Console.WriteLine("*****");

    Console.WriteLine("*****");
}
Console.WriteLine("*****");
Console.WriteLine("*****");
Console.WriteLine("Another Page");
Console.WriteLine("*****");
Console.WriteLine("*****");



// instance
BasketManager basketManager = new BasketManager();
basketManager.Add(prod1);
basketManager.Add(prod2);