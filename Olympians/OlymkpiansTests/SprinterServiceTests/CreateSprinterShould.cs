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
    public class CreateSprinterShould
    {
        [Fact]
        public void CreateSprinterShouldSucceed()
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
            sprinterService.Create(sprinter);
            var expected = sprinter;
            var actual = olympicsDatabase.Sprinters;

            //Assert
            Assert.Equal(expected, actual.FirstOrDefault());
        }
    }
}
