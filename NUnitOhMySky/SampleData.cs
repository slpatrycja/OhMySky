using OhMySky;
using OhMySky.Models;
using Bogus;

namespace NUnitOhMySky.Tests
{
    class SampleData
    {
        public Asteroid BogusAsteroid()
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

            return bogusAsteroid;
        }

        public PictureData BogusPicture()
        {
            var testPicture = new Faker<PictureData>()
           .RuleFor(o => o.Url, f => f.Internet.Url())
           .RuleFor(o => o.Title, f => f.Lorem.Sentence());
            var bogusPicture = testPicture.Generate();

            return bogusPicture;
        }
    }
}
