using FluentAssertions;
using Flx.Core.BAC;
using Flx.Core.Models;
using Flx.Shared.Responses;
using NUnit.Framework;

namespace Flx.testing.Core.BAC
{
    [TestFixture]
    public class CategoryBacTest
    {
        private CategoryBac _categoryBac;

        [SetUp]
        public void Setup()
        {
            //_categoryBac = new();
        }

        [Test]
        public async void InsertCategoryBacSuccessful()
        {
            //Arrange
            Category category = new()
            {
                Id = 1,
                Name = "Tecnology Information",
                Description = "Here you will find everything about tecnologies",
            };

            //Act
            ModelOperationResponse response = await _categoryBac.InsertCategoryAsync(category);

            //Asset
            response.HasErrorMessages.Should().BeFalse();
        }
    }
}
