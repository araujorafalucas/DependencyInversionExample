using DependencyInversionExampleApp.Entities;
using DependencyInversionExampleApp.Repositories;

namespace DependencyInversionExampleApp.Services;

public class ProductsService
{
    private readonly IProductsRepository ProductsRepository;
    public ProductsService(IProductsRepository productsRepository)
    {
        ProductsRepository = productsRepository;
    }

    public (bool isValid, string message) InsertNewProduct(Product product)
    {
        var productWithcodeInUse = ProductsRepository.GetByCode(product.Code);

        if (productWithcodeInUse is not null)
        {
            return (false, "The code is already in use.");
        }

        ProductsRepository.Add(product);

        return (true, "Product succefully inserted.");
    }

}

