using FluentAssertions;
using Flx.Domain.Domains;
using Flx.Domain.Responses;
using Flx.Domain.Validators;
using NUnit.Framework;

namespace Flx.test.Domain.Validations
{
    [TestFixture]
    public class CategoryValidatorTest
    {
        private CategoryValidator _categoryValidator;

        [Test]
        public void ValidateCategorySuccessfully()
        {
            //Arrange
            Category category = new()
            {
                Name = "Tecnology Information",
                Description = "Here you will find everything about tecnologies",
                Duration = 200
            };

            //Act
            CategoryInquiryResponse response = _categoryValidator.ValidateCategory(category);

            //Assert
            response.HasErrorMessages.Should().BeFalse();
        }
    }
}
