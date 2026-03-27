using AutoMapper;
using BudgetApp.Data.Entities;
using BudgetApp.Models;
using Moq;
using BudgetApp.Repositories.Contracts;
using BudgetApp.Services;
using FluentAssertions;

namespace BudgetApp.Tests.Services
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CategoryService _sut;
        private readonly List<Category> _fakeEntities;
        private readonly List<CategoryModel> _fakeModels;

        public CategoryServiceTests()
        {
            _mockRepo = new Mock<ICategoryRepository>();
            _mockMapper = new Mock<IMapper>();
            _sut = new CategoryService(_mockRepo.Object, _mockMapper.Object);

            _fakeEntities = new List<Category>
            {
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Groceries" }
            };

            _fakeModels = new List<CategoryModel>
            {
                new CategoryModel { Id = 1, Name = "Food" },
                new CategoryModel { Id = 2, Name = "Groceries" }
            };
        } 

        [Fact]
        public async Task GetAllCategoriesAsync_ReturnsMappedModels()
        {
            
            _mockMapper.Setup(m => m.Map<IEnumerable<CategoryModel>>(_fakeEntities))
                      .Returns(_fakeModels);

            // Act
            var result = await _sut.GetAllCategoriesAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(c => c.Name == "Food");
            result.Should().Contain(c => c.Name == "Groceries");

            _mockRepo.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_ReturnsMappedModel_WhenFound()
        {
            var entity = _fakeEntities[0];
            var model = _fakeModels[0];

            _mockRepo.Setup(r => r.GetByIdAsync(entity.Id))
                     .ReturnsAsync(entity);

            _mockMapper.Setup(m => m.Map<CategoryModel>(entity))
                       .Returns(model);

            var result = await _sut.GetCategoryByIdAsync(entity.Id);

            result.Should().NotBeNull();
            result!.Id.Should().Be(entity.Id);
            result.Name.Should().Be(entity.Name);

            _mockRepo.Verify(r => r.GetByIdAsync(entity.Id), Times.Once);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_ReturnsNotFound_WhenNull()
        {
            var entity = _fakeEntities[0];
            var model = _fakeModels[0];

            _mockRepo.Setup(r => r.GetByIdAsync(99))
                     .ReturnsAsync((Category?)null);

            var result = await _sut.GetCategoryByIdAsync(99);

            result.Should().BeNull();            
        }
    }
}