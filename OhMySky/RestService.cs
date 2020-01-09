using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OhMySky
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<AsteroidData> GetAsteroidData(string query, string currentDate)
        {
            AsteroidData data = new AsteroidData();

            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject googleSearch = JObject.Parse(content);
                    IList<JToken> results = googleSearch["near_earth_objects"][currentDate].Children().ToList();
                    IList<NearEarthObject> searchResults = new List<NearEarthObject>();

                    foreach (JToken result in results)
                    {
                        NearEarthObject searchResult = result.ToObject<NearEarthObject>();
                        searchResults.Add(searchResult);
                    }

                    data.NearEarthObjects = searchResults;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex);
            }

            return data;
        }

        public async Task<PictureData> GetPictureOfTheDay(string query)
        {
            PictureData data = new PictureData();

            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject result = JObject.Parse(content);
                    data = result.ToObject<PictureData>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex);
            }

            return data;
        }
    }
}

