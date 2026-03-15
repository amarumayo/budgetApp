using Budget.Api.Data.Entities;

public class CategoryServiceTests
{
    [Fact]
    public async Task GetAllCategoriesAsync_ReturnsMappedDtos()
    {
        // Arrange
        var mockRepo = new Mock<ICategoryRepository>();
        var mockMapper = new Mock<IMapper>();

        var fakeEntities = new List<Category>
        {
            new Category { Id = 1, Name = "Food" },
            new Category { Id = 2, Name = "Groceries" }
        };

        mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(fakeEntities);

        var fakeDtos = new List<CategoryModel>
        {
            new CategoryModel { Id = 1, Name = "Food" },
            new CategoryModel { Id = 2, Name = "Groceries" }
        };

        mockMapper.Setup(m => m.Map<IEnumerable<CategoryModel>>(fakeEntities))
                  .Returns(fakeDtos);

        var service = new CategoryService(mockRepo.Object, mockMapper.Object);

        // Act
        var result = await service.GetAllCategoriesAsync();

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain(c => c.Name == "Food");
        result.Should().Contain(c => c.Name == "Groceries");

        mockRepo.Verify(r => r.GetAllAsync(), Times.Once);
    }
}
