using FluentAssertions;
using Flx.Domain.BAC;
using Flx.Domain.Domains;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
using Flx.Shared.Responses;
using NUnit.Framework;

namespace Flx.testing.Domain.BAC
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
        public void InsertCategoryBacSuccessful()
        {
            //Arrange
            Category category = new()
            {
                Id = 1,
                Name = "Tecnology Information",
                Description = "Here you will find everything about tecnologies",
            };

            //ModelOperationRequest<Category> request = new(category);

            //Act
            ModelOperationResponse response = _categoryBac.InsertCategoryBac(category);

            //Asset
            response.HasErrorMessages.Should().BeFalse();
        }
    }
}
