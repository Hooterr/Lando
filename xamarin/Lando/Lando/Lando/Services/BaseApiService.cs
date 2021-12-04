using Lando.ApiModels;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Lando.Services
{
    public abstract class BaseApiService
    {
        protected readonly HttpClient http;
        protected readonly ISessionManager sessionManager;

        protected BaseApiService(IHttpClientFactory http, ISessionManager sessionManager)
        {
            this.http = http.CreateClient("api");
            this.sessionManager = sessionManager;
        }

        protected async Task<ApiResonseModel<T>> GetAsync<T>(string url)
        {
            var token = await sessionManager.GetTokenAsync();
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();

                await LogRequestAsync(response);

                var entity = JsonConvert.DeserializeObject<T>(contentString);
                
                return new ApiResonseModel<T>
                {
                    Success = true,
                    Entity = entity
                };
            }

            await LogRequestAsync(response);

            return new ApiResonseModel<T>
            {
                Success = false
            };
        }

        private async Task LogRequestAsync(HttpResponseMessage response)
        {
            Debug.WriteLine($"========================================================================");
            Debug.WriteLine(">>>>> OUTGOING HTTP REQUEST >>>>>>");
            Debug.WriteLine($"Method: {response.RequestMessage.Method}, URI: {response.RequestMessage.RequestUri}");
            Debug.WriteLine("<<<<< HTTP RESPOSNE <<<<<");
            Debug.WriteLine($"Response: {(int)response.StatusCode} {response.StatusCode}");
            try
            {
                dynamic parsedJson = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                string jsonString = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
                Debug.WriteLine(jsonString);
            }
            catch { }
            Debug.WriteLine($"========================================================================");

        }
    }
}
