using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OhMySky
{
    public class AsteroidData
    {
        [JsonProperty("near_earth_objects")]
        public NearEarthObjects NearEarthObjects { get; set; }
    }

    public class NearEarthObjects
    {
        [JsonProperty("2019-12-16")]
        public NearEarthObject[] NearEarthObject { get; set; }
    }

    public class NearEarthObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("neo_reference_id")]
        public string NeoReferenceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("designation")]
        public string Designation { get; set; }

        [JsonProperty("absolute_magnitude_h")]
        public double AbsoluteMagnitudeH { get; set; }

        [JsonProperty("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardous { get; set; }

        [JsonProperty("close_approach_data")]
        public CloseApproachData[] CloseApproachData { get; set; }

    }

    public class EstimatedDiameter
    {
        [JsonProperty("kilometers")]
        public KilometersData KilometersData { get; set; }
    }

    public class KilometersData
    {
        [JsonProperty("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class CloseApproachData
    {
        [JsonProperty("close_approach_date")]
        public string CloseApproachDate { get; set; }

        [JsonProperty("orbiting_body")]
        public string OrbitingBody { get; set; }

        [JsonProperty("relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; set; }
    }

    public class RelativeVelocity
    {
        [JsonProperty("kilometers_per_second")]
        public string KilometersPerSecond { get; set; }
    }
}