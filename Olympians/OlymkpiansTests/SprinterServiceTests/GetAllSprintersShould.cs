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
    public class GetAllSprintersShould
    {
        [Fact]
        public void GetAllSprintersShouldCucceed()
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
            var expected = olympicsDatabase.Sprinters;
            var result = sprinterService.GetAllSprinters();

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
