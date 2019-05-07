using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Copernicus.Common.FacebookClient
{
    public class FacebookClient : IFacebookClient
    {
        private readonly HttpClient _httpClient;

        public FacebookClient(string apiUrl)
        {
            _httpClient = new HttpClient {
                BaseAddress = new Uri(apiUrl)
            };
        }

        public async Task<dynamic> Get(string endpoint, string accessToken, string args = "")
        {
            var response = await _httpClient.GetAsync($"/{endpoint}?access_token={accessToken}&{args}");

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }
    }
}