using System;
using Newtonsoft.Json;

namespace OhMySky
{
    public class AsteroidData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public Boolean IsHazardous { get; set; }

    }
}