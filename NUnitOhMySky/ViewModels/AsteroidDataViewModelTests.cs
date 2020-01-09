using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OhMySky;
using System.Collections;
using Moq;
using Bogus;
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

            var testAsteroid = new Faker<iAsteroid>()
            .RuleFor(o => o.Id, f => f.Lorem.Word())
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .RuleFor(o => o.IsPotentiallyHazardous, f => f.Random.Bool())
            .RuleFor(o => o.EstimatedDiameter, f => f.Random.Double())
            .RuleFor(o => o.CloseApproachDate, f => f.Random.String())
            .RuleFor(o => o.RelativeVelocity, f => f.Random.String())
            .RuleFor(o => o.AbsoluteMagnitudeH, f => f.Random.Double());
            var bogusAsteroid = testAsteroid.Generate();

            var asteroidDataViewModel = new AsteroidDataViewModel();
            await asteroidDataViewModel.GetAsteroidData();
            Assert.That(asteroidDataViewModel.Asteroids[0].Id, Is.EqualTo(bogusAsteroid.Id));

        }


    }
        
}
