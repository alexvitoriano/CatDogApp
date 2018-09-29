using System;
using System.Collections.Generic;
using System.Text;

namespace CatDog.Services
{
    public static class HttpUtils
    {
        public static string CONTENT_TYPE = "application/json";

        public static string URL_DEFAULT_DOG = "https://api.thedogapi.com/v1/images/search?limit=25";

        public static string URL_DEFAULT_CAT = "https://api.thecatapi.com/v1/images/search?limit=25";

        public static string XAPIKEY_HEADER = "047ce37d-f577-4e4a-a04e-55f96b559efe";

    }
}
