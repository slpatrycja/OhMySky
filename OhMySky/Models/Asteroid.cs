using SQLite;
using OhMySky.Interfaces;

namespace OhMySky.Models
{
    public class Asteroid : iAsteroid
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPotentiallyHazardous { get; set; }
        public double EstimatedDiameter { get; set; }
        public double AbsoluteMagnitudeH { get; set; }
        public string CloseApproachDate { get; set; }
        public string RelativeVelocity { get; set; }
    }
}
