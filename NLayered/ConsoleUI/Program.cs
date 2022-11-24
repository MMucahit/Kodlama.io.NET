// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

ProductManager productManager = new ProductManager(new InMemoryProductDal());

foreach (var item in productManager.GetAll())
{
    Console.WriteLine(item.ProductName);
}

Console.WriteLine("-------------");

foreach (var item in productManager.GetAllByCategory(1))
{
    Console.WriteLine(item.ProductId.ToString() + " " + item.ProductName);
}

Console.WriteLine("-------------");

Product product = new Product
{
    ProductId = 1,
    CategoryId = 1,
    ProductName = "Asus",
    UnitPrice = 17500,
    UnitsInStock = 16
};

productManager.Update(product);
