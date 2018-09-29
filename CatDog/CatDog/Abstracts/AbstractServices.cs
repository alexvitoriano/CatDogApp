using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CatDog.Abstracts.ErrorHandler;

namespace CatDog.Abstracts
{
    public abstract class AbstractServices
    {

        public static string SerializeToJson(Object jsonRequest)
        {
            return JsonConvert.SerializeObject(jsonRequest);
        }

        public static object DeserializeFromJson(String jsonResponse)
        {
            return JsonConvert.DeserializeObject(jsonResponse);
        }
        public static T DeserializeFromJson<T>(String jsonResponse)
        {
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        internal async Task<T> SendAsync<T>(String uri, ApiMethodTypes methodType = ApiMethodTypes.MethodGet, Object body = null)
        {
            string responseString = "";
            try
            {
                using (var c = new HttpClient())
                {
                    var client = new HttpClient();
                    var clientPushAndroid = new HttpClient();
                    var clientPushiOS = new HttpClient();

                    client.Timeout = new TimeSpan(0, 0, 30);

                    HttpContent content = new StringContent(SerializeToJson(body), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = null;
                    switch (methodType)
                    {
                        case ApiMethodTypes.MethodPost:
                            response = await client.PostAsync(uri, content).ConfigureAwait(false);
                            break;
                        case ApiMethodTypes.MethodGet:
                            response = await client.GetAsync(uri).ConfigureAwait(false);
                            break;
                        case ApiMethodTypes.MethodPut:
                            response = await client.PutAsync(uri, content).ConfigureAwait(false);
                            break;
                        case ApiMethodTypes.MethodDelete:
                            response = await client.DeleteAsync(uri);
                            return (T)(object)response.IsSuccessStatusCode;
                        default:
                            return default(T);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                        return DeserializeFromJson<T>(responseString);
                    }
                    else
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                        {
                            ErrorModel err = DeserializeFromJson<ErrorModel>(
                                response.Content.ReadAsStringAsync().Result);
                            if (err != null)
                                throw new ONErrorHandler(err);
                        }
                        return default(T);
                    }

                }

            }
            catch (JsonReaderException j)
            {

                throw new ONErrorHandler(ErrorCode.JSON_CONVERTER);
            }
            catch (HttpRequestException h)
            {

                throw new ONErrorHandler(ErrorCode.HTTP_EXCEPTION);
            }
            catch (TaskCanceledException t)
            {

                throw new ONErrorHandler(ErrorCode.HTTP_EXCEPTION);
            }
            catch (ONErrorHandler e)
            {

                throw e;
            }
            catch (Exception ex)
            {

                throw new ONErrorHandler(ex);
            }

        }

        public enum ApiMethodTypes
        {
            MethodPost = 0,
            MethodGet = 1,
            MethodPut = 2,
            MethodDelete = 3,
        }

    }
}
