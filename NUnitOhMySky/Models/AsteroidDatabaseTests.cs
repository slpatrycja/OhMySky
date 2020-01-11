using NUnit.Framework;
using OhMySky;
using System.Threading.Tasks;
using OhMySky.Models;

namespace NUnitOhMySky.Tests
{
    [TestFixture]
    class AsteroidDatabaseTests
    {

        [Test]
        public async Task CheckIfItemSaves()
        {
            var sampleData = new SampleData();
            var bogusAsteroid = sampleData.BogusAsteroid();
            var asteroidDatabase = new AsteroidDatabase();
            var saveMethod = await asteroidDatabase.SaveItemAsync(bogusAsteroid);

            Assert.That(saveMethod, Is.EqualTo(1));
        }

        [Test]
        public async Task CheckIfItemDeletes()
        {
            var sampleData = new SampleData();
            var bogusAsteroid = sampleData.BogusAsteroid();
            var asteroidDatabase = new AsteroidDatabase();

            await asteroidDatabase.SaveItemAsync(bogusAsteroid);

            Assert.That(await asteroidDatabase.DeleteItemAsync(bogusAsteroid), Is.EqualTo(1));
        }

        [Test]
        public async Task CheckIfItemFetches()
        {
            var sampleData = new SampleData();
            var bogusAsteroid = sampleData.BogusAsteroid();
            var asteroidDatabase = new AsteroidDatabase();

            await asteroidDatabase.SaveItemAsync(bogusAsteroid);

            Assert.That(await asteroidDatabase.GetItemAsync(bogusAsteroid.Id), Is.TypeOf(typeof(Asteroid)));
        }


    }
        
}
