using DependencyInversionExampleApp.Entities;
using DependencyInversionExampleApp.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInversionExampleApp.Tests;

public class ProductsRepositoryMock : IProductsRepository
{
    private List<Product> Products;
    public ProductsRepositoryMock()
    {
        Products = new List<Product>();

        InitializeMockRepository();
    }

    private void InitializeMockRepository()
    {
        for (int index = 1; index < 10; index++)
        {
            Products.Add(new()
            {
                Code = index,
                Description = $"My fake product {index}"
            });
        }
    }

    public void Add(Product product)
    {
        Products.Add(product);
    }

    public Product? GetByCode(int code)
    {
        return Products.FirstOrDefault(x => x.Code == code);
    }
}

