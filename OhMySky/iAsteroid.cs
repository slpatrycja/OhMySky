using System;
namespace OhMySky
{
    public class iAsteroid
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool IsPotentiallyHazardous { get; set; }
        public double EstimatedDiameter { get; set; }
        public double AbsoluteMagnitudeH { get; set; }
        public string CloseApproachDate { get; set; }
        public string RelativeVelocity { get; set; }
    }
}
