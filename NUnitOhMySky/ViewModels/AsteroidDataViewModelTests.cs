using NUnit.Framework;
using OhMySky;
using System.Collections;
using System.Threading.Tasks;

namespace NUnitOhMySky.Tests
{
    [TestFixture]
    class AsteroidDataViewModelTests
    {
        [Test]
        public void CheckAsteroidListDataType()
        {
            var asteroidDataViewModel = new AsteroidDataViewModel();
            Assert.That(asteroidDataViewModel.Asteroids, Is.InstanceOf<IList>().And.Empty);
        }
        [Test]
        public async Task CheckFetchedAsteroidData()
        {
            var sampleData = new SampleData();
            var bogusAsteroid = sampleData.BogusAsteroid();
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
