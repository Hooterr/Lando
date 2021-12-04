using Lando.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lando.Services
{
    public class ApiService : BaseApiService, IApiService
    {
        public ApiService(IHttpClientFactory factory, ISessionManager sessionManager) : base(factory, sessionManager)
        {

        }

        public async Task<ApiResonseModel<CategoriesModel>> GetCategories()
        {
            return await GetAsync<CategoriesModel>("sale/categories");
        }
    }
}
