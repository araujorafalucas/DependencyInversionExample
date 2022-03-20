
using DependencyInversionExampleApp.Repositories;
using DependencyInversionExampleApp.Services;

IProductsRepository productsRepository = new ProductsRepository();

var productsService = new ProductsService(productsRepository);

var statusInsert = productsService.InsertNewProduct(new()
{
    Code = 1,
    Description = "my new product 1"
});


Console.WriteLine($"Is valid: {statusInsert.isValid}");
Console.WriteLine($"Message: {statusInsert.message}");
Console.ReadKey();


