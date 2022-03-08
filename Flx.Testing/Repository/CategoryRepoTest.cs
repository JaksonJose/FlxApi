using FluentAssertions;
using Flx.Domain.Domains;
using Flx.Domain.Responses;
using NUnit.Framework;

namespace Flx.Testing.Repository
{
    [TestFixture]
    public class CategoryRepoTest
    {
        //private Mock<ICategoryRepository> _mockCategoryRepository;

        [Test]
        [Description("Test Fetch All Category Success")]
        public async Task FetchAllCategorySuccess()
        {
            //Arrange
            Category category = new();

            InquiryResponse<Category> response = new();

            //Act

            //Assert
            response.HasErrorMessages.Should().BeFalse();
        }
    }
}
