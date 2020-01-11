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
    class AsteroidDatabaseTests
    {
        [Test]
        public async void CheckDatabaseConnection()
        {
            var asteroidDatabase = new AsteroidDatabase();
            //Assert.That(asteroidDatabase.initialized).Is(true);
        }
        [Test]
        public async Task CheckFetchedAsteroidData()
        {
            var asteroidDatabase = new AsteroidDatabase();

        }


    }
        
}
