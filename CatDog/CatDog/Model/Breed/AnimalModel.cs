using Newtonsoft.Json;
using System.Collections.Generic;

namespace CatDog.Model.Breed
{
    public class AnimalModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("breeds")]
        public List<BreedModel> Breeds { get; set; }
               

    }
}
