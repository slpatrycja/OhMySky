using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OhMySky;
using System.Collections;
using Bogus;
using System.Threading.Tasks;
using OhMySky.Models;

namespace NUnitOhMySky.Tests
{
    [TestFixture]
    class FavouriteAsteroidsViewModelTests
    {
        [Test]
        public void CheckDatabaseConnection()
        {
            var asteroidDataViewModel = new AsteroidDataViewModel();
            Assert.That(asteroidDataViewModel.Asteroids, Is.InstanceOf<IList>().And.Empty);
        }
        [Test]
        public async Task CheckFetchedAsteroidData()
        {
            var testAsteroid = new Faker<Asteroid>()
            .RuleFor(o => o.Id, f => f.Random.Number(0, 200))
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .RuleFor(o => o.IsPotentiallyHazardous, f => f.Random.Bool())
            .RuleFor(o => o.EstimatedDiameter, f => f.Random.Double())
            .RuleFor(o => o.CloseApproachDate, f => f.Random.String())
            .RuleFor(o => o.RelativeVelocity, f => f.Random.String())
            .RuleFor(o => o.AbsoluteMagnitudeH, f => f.Random.Double());
            var bogusAsteroid = testAsteroid.Generate();

            var asteroidDataViewModel = new AsteroidDataViewModel();
            await asteroidDataViewModel.GetAsteroidData();

            var firstFetchedAsteroid = asteroidDataViewModel.Asteroids[0];

            Assert.That(firstFetchedAsteroid, Has.Property("Id").And.Property("Id").InstanceOf(bogusAsteroid.Id.GetType()));
            Assert.That(firstFetchedAsteroid, Has.Property("Name").And.Property("Name").InstanceOf(bogusAsteroid.Name.GetType()));
            Assert.That(firstFetchedAsteroid, Has.Property("IsPotentiallyHazardous").And.Property("IsPotentiallyHazardous").InstanceOf(bogusAsteroid.IsPotentiallyHazardous.GetType()));
            Assert.That(firstFetchedAsteroid, Has.Property("EstimatedDiameter").And.Property("EstimatedDiameter").InstanceOf(bogusAsteroid.EstimatedDiameter.GetType()));
            Assert.That(firstFetchedAsteroid, Has.Property("CloseApproachDate").And.Property("CloseApproachDate").InstanceOf(bogusAsteroid.CloseApproachDate.GetType()));
            Assert.That(firstFetchedAsteroid, Has.Property("RelativeVelocity").And.Property("RelativeVelocity").InstanceOf(bogusAsteroid.RelativeVelocity.GetType()));
            Assert.That(firstFetchedAsteroid, Has.Property("AbsoluteMagnitudeH").And.Property("AbsoluteMagnitudeH").InstanceOf(bogusAsteroid.AbsoluteMagnitudeH.GetType()));
        }


    }
        
}
