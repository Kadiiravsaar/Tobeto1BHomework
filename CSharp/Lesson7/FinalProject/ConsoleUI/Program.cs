using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

ProductManager productManager = new ProductManager(new InMemoryProductDal());
foreach (var prodManagers in productManager.GetAll())
{
    Console.WriteLine(prodManagers.ProductName);
}

ProductManager productManager1 = new ProductManager(new EfProductDal());

foreach (var prodManagers1 in productManager1.GetAll())
{
    Console.WriteLine(prodManagers1.ProductName);
}
