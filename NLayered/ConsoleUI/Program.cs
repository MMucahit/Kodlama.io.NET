// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

ProductTest();
//CategoryTest();
//CustomerTest();
static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    foreach (var item in productManager.GetAllByCategoryId(1))
    {
        Console.WriteLine(item.CategoryId.ToString() + "-" + item.ProductName);
    }

    Console.WriteLine("------DTO------");

    foreach (var item in productManager.GetProductDetails())
    {
        Console.WriteLine(item.CategoryName + "-" + item.ProductName);
    }

}
static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

    foreach (var item in categoryManager.GetAllByCategoryId(1))
    {
        Console.WriteLine(item.CategoryId.ToString() + "-" + item.CategoryName);
    }
    Console.WriteLine("--------------");

}
static void CustomerTest()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

    foreach (var item in customerManager.GetAllByCategoryId(1))
    {
        Console.WriteLine(item.CustomerId.ToString() + "-" + item.ContactName);
    }
    Console.WriteLine("--------------");

}