using Olympians.Models;
using Olympians.Models.Databases;
using Olympians.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olympians.Tests.SprinterServiceTests
{
    public class DeleteSprinterShould
    {
        [Fact]
        public void DeleteSprinterShouldSucceed()
        {
            //Arrange
            var olympicsDatabase = new OlympianDatabase();
            var records = new Dictionary<string, string>()
            {
                {"100", "8.7"},
                {"200", "18.5"}
            };
            var records1 = new Dictionary<string, string>()
            {
                {"100", "8.3"},
                {"200", "19"}
            };

            var sprinter = new Sprinter("ivan", "ivanov", "bulgaria", records);
            var sprinter1 = new Sprinter("georgi", "georgiev", "bulgaria", records1);
            var sprinterService = new SprinterService(olympicsDatabase);
            olympicsDatabase.Sprinters.Add(sprinter);
            olympicsDatabase.Sprinters.Add(sprinter1);

            //Act
            var expected = sprinter;
            sprinterService.Delete(sprinter1);
            var actual = olympicsDatabase.Sprinters;

            //Assert
            Assert.Equal(expected, actual.FirstOrDefault());
        }
        [Fact]
        public void DeleteSprinterShouldReturnFalseIfBoxerIsNull()
        {
            //Arrange
            var olympicsDatabase = new OlympianDatabase();
            var records = new Dictionary<string, string>()
            {
                {"100", "8.7"},
                {"200", "18.5"}
            };
            var sprinter = new Sprinter("ivan", "ivanov", "bulgaria", records);
            var sprinterService = new SprinterService(olympicsDatabase);

            //Act
            var expected = false;
            var result = sprinterService.Delete(sprinter);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
