using DependencyInversionExampleApp.Entities;

namespace DependencyInversionExampleApp.Repositories;

public class ProductsRepository : IProductsRepository
{
    private List<Product> Products;
    public ProductsRepository()
    {
        Products = new List<Product>();
        InitializeRepository();
    }

    private void InitializeRepository()
    {

        for (int index = 1; index < 10; index++)
        {
            Products.Add(new Product()
            {
                Code = index,
                Description = $"My real product {index}"
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

