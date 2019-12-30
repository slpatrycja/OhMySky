using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OhMySky;

namespace NUnitOhMySky.Tests
{
    [TestFixture]
    class AsteroidDataViewModelTests
    {
        [Test]
        public void GetDataTest()
        {
            var asteroidDataViewModel = new AsteroidDataViewModel();
            Assert.IsNotNull(asteroidDataViewModel.GetAsteroidData());
        }
        [Test]
        public void GenerateUriTest()
        {

        }
    }
}
