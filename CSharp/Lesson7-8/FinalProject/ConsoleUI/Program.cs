using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

#region Lesson 7
//ProductManager productManager = new ProductManager(new InMemoryProductDal());
//foreach (var prodManagers in productManager.GetAll())
//{
//    Console.WriteLine(prodManagers.ProductName);
//}

#endregion

#region Lesson 8

ProductManager productManager1 = new ProductManager(new EfProductDal());

//foreach (var prodManagers1 in productManager1.GetAll())
//{
//    Console.WriteLine(prodManagers1.ProductName);
//}

foreach (var prodManagers1 in productManager1.GetByUnitPrice(20, 100))
{
    Console.WriteLine(prodManagers1.ProductName);
}

#endregion

