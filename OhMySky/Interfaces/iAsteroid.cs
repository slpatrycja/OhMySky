namespace OhMySky
{
    interface iAsteroid
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsPotentiallyHazardous { get; set; }
        double EstimatedDiameter { get; set; }
        double AbsoluteMagnitudeH { get; set; }
        string CloseApproachDate { get; set; }
        string RelativeVelocity { get; set; }
    }
}
