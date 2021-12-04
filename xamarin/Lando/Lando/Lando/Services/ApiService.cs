using Lando.ApiModels;
using Lando.ApiModels.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lando.Services
{
    public class ApiService : BaseApiService, IApiService
    {
        public ApiService(IHttpClientFactory factory, ISessionManager sessionManager) : base(factory, sessionManager)
        {

        }

        public async Task<ApiResonseModel<MeModel>> GetMeAsync()
        {
            return await GetAsync<MeModel>("me");
        }

        public async Task<ApiResonseModel<CategoriesModel>> GetCategoriesAsync(string parentId = null)
        {
            if (string.IsNullOrEmpty(parentId))
            {
                return await GetAsync<CategoriesModel>("sale/categories");
            }

            return await GetAsync<CategoriesModel>($"sale/categories?parent.id={parentId}");
        }

        public async Task<ApiResonseModel<OffersResponseModel>> GetProductsAsync(Action<GetOffersParameters> action)
        {
            var options = new GetOffersParameters();
            action.Invoke(options);

            var query = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrEmpty(options.CategoryId))
            {
                query.Add("category.id", options.CategoryId);
            }

            if (options.Limit != null)
            {
                query.Add("limit", options.Limit.ToString());
            }

            if (options.Offset != null)
            {
                query.Add("offset", options.Offset.ToString());
            }

            if (!string.IsNullOrEmpty(options.SearchPhrase))
            {
                query.Add("phrase", options.SearchPhrase);
            }

            return await GetAsync<OffersResponseModel>($"offers/listing?{query}");

        }

        public async Task<ApiResonseModel<OfferDetailsResponseModel>> GetOfferDetailsAsync(string id)
        {
            return await GetAsync<OfferDetailsResponseModel>($"sale/offers/{id}");
        }
    }
}
