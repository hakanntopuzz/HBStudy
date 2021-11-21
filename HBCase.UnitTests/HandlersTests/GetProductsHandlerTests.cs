using HBCase.Business.Handlers;
using HBCase.Business.Services;
using HBCase.Data.Repositories;
using HBCase.Model.Entities;
using HBCase.Model.Results;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBCase.UnitTests.HandlersTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class GetProductsHandlerTests
    {
        #region members & setup

        Mock<ILogger<GetProductsHandler>> logger;
        Mock<IRepository<Product>> productRepository;
        Mock<ICacheService> cacheService;

        GetProductsHandler getProductsHandler;

        [SetUp]
        public void Initialize()
        {
            logger = new Mock<ILogger<GetProductsHandler>>();
            productRepository = new Mock<IRepository<Product>>();
            cacheService = new Mock<ICacheService>();

            getProductsHandler
                = new GetProductsHandler(logger.Object, productRepository.Object, cacheService.Object);
        }

        #endregion

        [Test]
        public void Handle_NameAndCategoryIdIsNull_ReturnNull()
        {
            var response = new BaseResponseResult<List<ProductResult>>();

            // Arrange
            menuViewModelFactory.Setup(x => x.CreateMenuListViewModel()).Returns(viewModel);

            // Act
            var result = controller.Index();

            // Assert
            result.Should().BeViewResult();
        }
    }
}
