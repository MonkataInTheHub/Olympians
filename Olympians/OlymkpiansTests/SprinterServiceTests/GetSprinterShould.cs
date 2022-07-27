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
    public class GetSprinterShould
    {
        [Fact]
        public void GetSprinterShouldSucceed()
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
            olympicsDatabase.Sprinters.Add(sprinter);

            //Act
            var result = sprinterService.Get(sprinter.FirstName, sprinter.LastName);
            var expected = sprinter;

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
