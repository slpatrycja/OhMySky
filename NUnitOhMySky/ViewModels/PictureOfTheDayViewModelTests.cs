using NUnit.Framework;
using OhMySky;
using System.Threading.Tasks;
using OhMySky.Interfaces;

namespace NUnitOhMySky.Tests
{
    [TestFixture]
    class PictureOfTheDayViewModelTests
    {
        [Test]
        public async Task CheckPictureDataType()
        {
            var pictureOfTheDay = new PictureOfTheDayViewModel();
            await pictureOfTheDay.GetPictureData();

            Assert.That(pictureOfTheDay.Picture, Is.InstanceOf<iPicture>());
        }
        [Test]
        public async Task CheckFetchedPictureData()
        {
            var sampleData = new SampleData();
            var bogusPicture = sampleData.BogusPicture();
            var pictureOfTheDay = new PictureOfTheDayViewModel();
            await pictureOfTheDay.GetPictureData();

            var fetchedPicture = pictureOfTheDay.Picture;

            Assert.That(fetchedPicture, Has.Property("Url").And.Property("Url").InstanceOf(bogusPicture.Url.GetType()));
            Assert.That(fetchedPicture, Has.Property("Title").And.Property("Title").InstanceOf(bogusPicture.Title.GetType()));
        }


    }
        
}
