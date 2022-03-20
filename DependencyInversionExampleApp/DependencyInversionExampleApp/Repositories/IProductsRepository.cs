using DependencyInversionExampleApp.Entities;
namespace DependencyInversionExampleApp.Repositories;

public interface IProductsRepository
{
    void Add(Product product);
    Product? GetByCode(int code);
}

