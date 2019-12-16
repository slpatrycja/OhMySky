using System;
using Newtonsoft.Json;

namespace OhMySky
{   
    public class AsteroidData
    {
        [JsonProperty("links")]
        public Links Links { get; set; }

    }

    public class Links
    {
        [JsonProperty("near_earth_objects")]
        public List<NearEarthObject> NearEarthObjecs { get; set; }
    }

    public class NearEarthObjects
    {
        [JsonProperty("element_count")]
        public int ElementCount { get; set; }
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
        public double EstimatedDiameter { get; set; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardous { get; set; }

    }

    public class EstimatedDiameters
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
}