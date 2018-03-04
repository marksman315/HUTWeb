using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HUTWeb.Helpers
{
    public static class HttpHelper
    {
        public static async Task<string> GetValues(Uri uri)
        {            
            using (var client = GetHttpClient())
            {                
                var result = await client.GetStringAsync(uri).ConfigureAwait(false);
                return result;
            }
        }

        public static async Task<string> PostValues(Uri uri, object model)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            using (var client = GetHttpClient())
            {
                var httpResponse = await client.PostAsync(uri, httpContent).ConfigureAwait(false);
                
                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return responseContent.ToString();
                }
            }

            return null;
        }

        public static async Task<string> PutValues(Uri uri, object model)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            using (var client = GetHttpClient())
            {
                var httpResponse = await client.PutAsync(uri, httpContent).ConfigureAwait(false);

                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return responseContent.ToString();
                }
            }

            return null;
        }

        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            return client;             
        }
    }
}