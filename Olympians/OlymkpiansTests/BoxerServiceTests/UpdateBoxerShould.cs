using Olympians.Models;
using Olympians.Models.Databases;
using Olympians.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olympians.Tests.BoxerServiceTests
{
    public class UpdateBoxerShould
    {
        [Fact]
        public void UpdateBoxerShouldSucceed()
        {
            //Arrange
            var database = new OlympianDatabase();
            var boxerService = new BoxerService(database);

            var boxer = new Boxer("ivan", "ivanov", "bulgaria", Olympians.Models.Enums.Category.Featherweight, 15, 6);
            var boxer1 = new Boxer("ivan", "ivanov", "bulgaria123", Olympians.Models.Enums.Category.Flyweight, 20, 15);

            database.Boxers.Add(boxer);

            //Act
            var expected = boxer1;
            boxerService.Update(boxer1);
            var actual = database.Boxers.Where(x => x.FirstName == boxer.FirstName && x.LastName == boxer.LastName);

            //Assert
            Assert.Equal(expected.FirstName, actual.FirstOrDefault().FirstName);
            Assert.Equal(expected.LastName, actual.FirstOrDefault().LastName);
            Assert.Equal(expected.Country, actual.FirstOrDefault().Country);
            Assert.Equal(expected.BoxingCategory, actual.FirstOrDefault().BoxingCategory);
            Assert.Equal(expected.Wins, actual.FirstOrDefault().Wins);
            Assert.Equal(expected.Losses, actual.FirstOrDefault().Losses);


        }
        [Fact]
        public void UpdateBoxerShouldThrowException()
        {
            //Arrange
            var database = new OlympianDatabase();
            var boxerService = new BoxerService(database);

            var boxer = new Boxer("ivan", "ivanov", "bulgaria", Olympians.Models.Enums.Category.Featherweight, 15, 6);
            var boxer1 = new Boxer("ivan", "ivanov", "bulgaria123", Olympians.Models.Enums.Category.Flyweight, 40, 34);

             //Act & Assert
            Assert.Throws<Exception>(() => boxerService.Update(boxer1));

        }
    }
}
