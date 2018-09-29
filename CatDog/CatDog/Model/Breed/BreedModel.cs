using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatDog.Model.Breed
{
    public class BreedModel
    {
    }


    public class MeasureModel
    {
        [JsonProperty("imperial")]
        public string Imperial { get; set; }

        [JsonProperty("metric")]
        public string Metric { get; set; }

    }

}
