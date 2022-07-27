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
    public class UpdateSprinterShould
    {
        [Fact]
        public void UpdateBoxerShouldSucceed()
        {
            //Arrange
            var olympicsDatabase = new OlympianDatabase();
            var sprinterService = new SprinterService(olympicsDatabase);
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
            var sprinter1 = new Sprinter("ivan", "ivanov", "Gruziq", records1);
            olympicsDatabase.Sprinters.Add(sprinter);

            //Act
            var expected = sprinter1;
            sprinterService.Update(sprinter1);
            var actual = olympicsDatabase.Sprinters.Where(x => x.FirstName == sprinter.FirstName && x.LastName == sprinter.LastName);

            //Assert
            Assert.Equal(expected.FirstName, actual.FirstOrDefault().FirstName);
            Assert.Equal(expected.LastName, actual.FirstOrDefault().LastName);
            Assert.Equal(expected.Country, actual.FirstOrDefault().Country);
            Assert.Equal(expected.PersonalRecords, actual.FirstOrDefault().PersonalRecords);

        }
        [Fact]
        public void UpdateSprinterShouldThrowException()
        {
            // Arrange
            var database = new OlympianDatabase();
            var sprinterService = new SprinterService(database);

            var dictionary1 = new Dictionary<string, string>();
            dictionary1.Add("100", "9.58");

            var dictionary2 = new Dictionary<string, string>();
            dictionary1.Add("200", "19.58");

            var sprinter = new Sprinter("ivan", "ivanov", "bulgaria", dictionary1);
            var sprinter1 = new Sprinter("ivan", "ivanov", "bulgaria", dictionary2);

            //Act & Assert
            Assert.Throws<Exception>(() => sprinterService.Update(sprinter1));

        }
    }
}
