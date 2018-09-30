using CatDog.Abstracts;
using CatDog.Model.Breed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatDog.Services.Breed
{
    public class AnimalServices: AbstractServices
    {

        public async Task<List<AnimalModel>> GetAnimalsServiceAsync(bool isDog)
        {
            List<AnimalModel> lstTickets = new List<AnimalModel>();
            HttpClient oHttpClient = new HttpClient();
            oHttpClient.Timeout = new TimeSpan(0, 1, 0);

            string url;

            if (isDog)
                url = HttpUtils.URL_DEFAULT_DOG;
            else
                url = HttpUtils.URL_DEFAULT_CAT;

            var ret = await oHttpClient.GetAsync(url);

            if (ret.IsSuccessStatusCode)
            {
                try
                {
                    var request = ret.Content.ReadAsStringAsync().Result;

                    lstTickets = JsonConvert.DeserializeObject<List<AnimalModel>>(request);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                
            }

            return lstTickets;

        }
    }
}
