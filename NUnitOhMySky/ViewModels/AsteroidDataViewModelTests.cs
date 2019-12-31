using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OhMySky;
using System.Collections;

namespace NUnitOhMySky.Tests
{
    [TestFixture]
    class AsteroidDataViewModelTests
    {
        [Test]
        public void GetDataTest()
        {
            var asteroidDataViewModel = new AsteroidDataViewModel();
            Assert.That(asteroidDataViewModel.Asteroids, Is.InstanceOf<IList>());
        }
        [Test]
        public void GenerateUriTest()
        {

        }
    }
}
