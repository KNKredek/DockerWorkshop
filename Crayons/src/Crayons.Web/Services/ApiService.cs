using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Crayons.Web.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Crayons.Web.Services
{
    public class ApiService : IApiService
    {
        protected HttpClient _client;
        public ApiService(string baseUrl)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> Get<T> (string url) where T : class
        {
            T result;

            var serializerSettings = new JsonSerializerSettings ();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver ();
            result = JsonConvert.DeserializeObject<T> (await (await _client.GetAsync (url)).Content.ReadAsStringAsync (), serializerSettings);

            return result;
        }

        public async Task Post<T> (T entity, string url, string token = "")
        {
            if(token != String.Empty)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
            var content = JsonConvert.SerializeObject (entity);
            HttpRequestMessage request = new HttpRequestMessage (HttpMethod.Post, url);
            request.Content = new StringContent (content, Encoding.UTF8, "application/json");
            var response = await _client.SendAsync (request);
        }
        
    }
}