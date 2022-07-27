using System.Linq;
using Xunit;
using Olympians.Models;
using Olympians.Models.Databases;
using Olympians.Services;

namespace Olympians.Tests.BoxerServiceTests
{
    public class CreateBoxerShould
    {
        [Fact]
        public void CreateBoxerShouldSucceed()
        {
            //Arrange
            var olympicsDatabase = new OlympianDatabase();
            var boxer = new Boxer("ivan", "ivanov", "bulgaria", Olympians.Models.Enums.Category.Featherweight, 15, 6);
            var boxerService = new BoxerService(olympicsDatabase);

            //Act
            boxerService.Create(boxer);
            var expected = boxer;
            var actual = olympicsDatabase.Boxers;

            //Assert
            Assert.Equal(expected, actual.FirstOrDefault());
        }
    }
}
