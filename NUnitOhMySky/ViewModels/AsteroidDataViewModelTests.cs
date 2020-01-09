using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OhMySky;
using System.Collections;
using Moq;
using System.Threading.Tasks;

namespace NUnitOhMySky.Tests
{
    [TestFixture]
    class AsteroidDataViewModelTests
    {
        [Test]
        public void CheckAsteroidsDataType()
        {
            Mock<IList> mockIList = new Mock<IList>();
            var asteroidDataViewModel = new AsteroidDataViewModel();
            Assert.That(asteroidDataViewModel.Asteroids, Is.InstanceOf<IList>());
        }
        [Test]
        public async Task GetAsteroidData()
        {
            var asteroidDataViewModel = new AsteroidDataViewModel();
            await asteroidDataViewModel.GetAsteroidData();
            Assert.That(asteroidDataViewModel.Asteroids[0], Is.EqualTo("s"));

        }
    }
}
