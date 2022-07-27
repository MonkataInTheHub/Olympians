﻿using Olympians.Models;
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
    public class DeleteBoxerShould
    {
        [Fact]
        public void DeleteBoxerShouldSucceed()
        {
            //Arrange
            var olympicsDatabase = new OlympianDatabase();
            var boxer = new Boxer("ivan", "ivanov", "bulgaria", Olympians.Models.Enums.Category.Featherweight, 15, 6);
            var boxer1 = new Boxer("georgi", "georgiev", "bulgaria", Olympians.Models.Enums.Category.Featherweight, 20, 6);
            var boxerService = new BoxerService(olympicsDatabase);
            olympicsDatabase.Boxers.Add(boxer1);

            //Act
            boxerService.Delete(boxer1);

            //Assert
            Assert.False(olympicsDatabase.Boxers.Contains(boxer1));
        }
        [Fact]
        public void DeleteBoxerShouldReturnFalseIfBoxerIsNull()
        {
            //Arrange
            var olympicsDatabase = new OlympianDatabase();
            var boxer = new Boxer("ivan", "ivanov", "bulgaria", Olympians.Models.Enums.Category.Featherweight, 15, 6);
            var boxerService = new BoxerService(olympicsDatabase);

            //Act
            var expected = false;
            var result = boxerService.Delete(boxer);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
