using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

//Autofac Configuration
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});
//

// Add services to the container.
// IoC // Autofac implementasyonu yaptýk.
//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();

//builder.Services.AddSingleton<ICategoryService, CategoryManager>();
//builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();

//builder.Services.AddSingleton<ICustomerService, CustomerManager>();
//builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();
//

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
