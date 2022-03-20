using DependencyInversionExampleApp.Repositories;
using DependencyInversionExampleApp.Services;
using Xunit;
using NSubstitute;
using DependencyInversionExampleApp.Entities;

namespace DependencyInversionExampleApp.Tests;

public class ProductServiceTests
{
    [Fact]
    public void OnInsertProductWithExistingCodeShouldReturnIsNotValid()
    {
        //arrange
        IProductsRepository productsRepository = new ProductsRepositoryMock();

        var productsService = new ProductsService(productsRepository);

        //act
        var statusInsert = productsService.InsertNewProduct(new()
        {
            Code = 1,
            Description = "My new test product 1"
        });

        //assert
        Assert.False(statusInsert.isValid);
    }

    [Fact]
    public void OnInsertProductWithNonExistingCodeShouldReturnIsValid()
    {
        //arrange
        IProductsRepository productsRepository = Substitute.For<IProductsRepository>();
        productsRepository.GetByCode(11).Returns(null as Product);

        var productsService = new ProductsService(productsRepository);

        //act
        var statusInsert = productsService.InsertNewProduct(new()
        {
            Code = 11,
            Description = "My new test product 11"
        });

        //assert
        Assert.True(statusInsert.isValid);
    }
}
