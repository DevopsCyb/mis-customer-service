using Microsoft.AspNetCore.Mvc;
using Mis.Services.Customer.Api.Controllers;
using Mis.Services.Customer.Api.DTOs;
using Mis.Services.Customer.Api.Models;
using Mis.Services.Customer.Api.Repository;
using Moq;
using Xunit;

namespace Mis.Services.Customer.Api.UnitTests.Controllers
{
    public class CustomerControllerTests
    {
        private readonly CustomersController _customersController;
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;

        private readonly Mock<MisServicesCustomerDatabaseContext> _misServicesCustomerDatabaseContextmis;

        public CustomerControllerTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _misServicesCustomerDatabaseContextmis= new Mock<MisServicesCustomerDatabaseContext>();
            _customersController = new CustomersController(_misServicesCustomerDatabaseContextmis.Object, _customerRepositoryMock.Object);
        }
















        



        [Fact]
        public async Task GetAllAsync_ShouldReturnOkResult_WhenCustomersExist1()
        {
            // Arrange
            var expectedCustomers = new List<Mis.Services.Customer.Api.Models.Customer>
        {
         new Mis.Services.Customer.Api.Models.Customer { CustomerId = 1 },
        new Mis.Services.Customer.Api.Models.Customer { CustomerId = 2},
        new Mis.Services.Customer.Api.Models.Customer { CustomerId = 3 }
        };
            _customerRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedCustomers);

            // Act
            var result = await _customersController.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualCustomers = Assert.IsType<List<Mis.Services.Customer.Api.Models.Customer>>(okResult.Value);
            Assert.Equal(expectedCustomers.Count, actualCustomers.Count);
        }



















    }








































    //public class CustomerControllerTests
    //{

    //    private readonly CustomersController _customerController;
    //    public CustomerControllerTests(object mockCustomerRepository)
    //    {
    //        var mockCustomerRepository = new Mock<ICustomerRepository>();
    //        mockCustomerRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<CustomerDto>());
    //        _customerController = new CustomerController(mockCustomerRepository.Object);
    //    }
    //    [Fact]
    //    public async Task GetCustomerReturnsOkResult()
    //    {
    //        // Act
    //        var result = await _customerController.GetAllAsync();

    //        // Assert
    //        Assert.IsType<OkObjectResult>(result.Result);
    //    }
    //}



    //public class CustomerControllerTests
    //{
    //    private readonly CustomersController _customersController;

    //    public CustomerControllerTests()

    //    {
    //        // Arrange
    //        var mockCustomerRepository = new Mock<ICustomerRepository>();

    //        mockCustomerRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<CustomerDto>());

    //        _customersController = new CustomersController(mockCustomerRepository.Object);
    //    }
    //    [Fact]
    //    public async Task GetAllAsync_ReturnsOkResult()
    //    {
    //        // Act
    //        var result = await _customersController.GetAllAsync();
    //        // Assert
    //        Assert.IsType<OkObjectResult>(result.Result);
    //    }
    //}
}