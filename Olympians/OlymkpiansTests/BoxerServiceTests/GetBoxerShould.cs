using Olympians.Models;
using Olympians.Models.Databases;
using Olympians.Services;
using Xunit;

namespace OlymkpiansTests
{
    public class GetBoxerShould
    {
        [Fact]
        public void GetBoxerShouldReturnRight()
        {
            //Arrange
            var boxer = new Boxer("ivan", "ivanov", "bulgaria", Olympians.Models.Enums.Category.Featherweight, 15, 6);
            var olympicsDatabase = new OlympianDatabase();
            olympicsDatabase.Boxers.Add(boxer);
            var boxerService = new BoxerService(olympicsDatabase);

            //Act
            var result = boxerService.Get(boxer.FirstName, boxer.LastName);
            var expected = boxer;

            //Assert
            Assert.Equal(expected, result);
        }
    }
}