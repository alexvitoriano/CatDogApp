using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatDog.Abstracts.ErrorHandler
{
    public class ErrorModel
    {
        [JsonProperty("verb")]
        public string Verb { get; set; }


        [JsonProperty("exception")]
        public string exception { get; set; }


        [JsonProperty("path")]
        public string Path { get; set; }


        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }


    }
}
