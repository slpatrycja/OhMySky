namespace OhMySky.Interfaces
{
    interface iAsteroid
    {
        int Id { get; set; }
        string Name { get; set; }
        double EstimatedDiameter { get; set; }
        double AbsoluteMagnitudeH { get; set; }
        string CloseApproachDate { get; set; }
        string RelativeVelocity { get; set; }
        bool IsPotentiallyHazardous { get; set; }
        bool IsFavourite { get; set; }
    }
}
