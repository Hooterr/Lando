using Lando.ApiModels;
using Newtonsoft.Json;
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

                var entity = JsonConvert.DeserializeObject<T>(contentString);
                
                return new ApiResonseModel<T>
                {
                    Success = true,
                    Entity = entity
                };
            }

            return new ApiResonseModel<T>
            {
                Success = false
            };
        }
    }
}
