using Newtonsoft.Json;

namespace CatDog.Model.Breed
{
    public class BreedModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("life_span")]
        public string LifeSpan { get; set; }

        [JsonProperty("breed_for")]
        public string BreedFor { get; set; }

        [JsonProperty("breed_group")]
        public string BreedGroup { get; set; }

        [JsonProperty("temperament")]
        public string Temperament { get; set; }

        [JsonProperty("weight")]
        public MeasureModel Weight { get; set; }

        [JsonProperty("height")]
        public MeasureModel Height { get; set; }

    }
    
    public class MeasureModel
    {
        [JsonProperty("imperial")]
        public string Imperial { get; set; }

        [JsonProperty("metric")]
        public string Metric { get; set; }

    }

}
