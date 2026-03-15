using BudgetApp.Models;
using Moq;
using BudgetApp.Services.Contracts;
using FluentAssertions;
using BudgetApp.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace BudgetApp.Tests.Controllers
{
    public class CategoryControllerTests
    {
        [Fact]
        public async Task GetAllReturnsOKWithCategories()
        {
            // Arrange
            var mockService = new Mock<ICategoryService>();

            var fakeModels = new List<CategoryModel>
        {
            new CategoryModel {Id = 1, Name = "Food"}
        };

            mockService.Setup(s => s.GetAllCategoriesAsync())
                    .ReturnsAsync(fakeModels);

            var controller = new CategoriesController(mockService.Object);

            // Act
            var result = await controller.GetAllCategories();

            var ok = result as OkObjectResult;
            ok.Should().NotBeNull();

            var returned = ok.Value as IEnumerable<CategoryModel>;

            returned.Should().HaveCount(1);

        }
    }
}
