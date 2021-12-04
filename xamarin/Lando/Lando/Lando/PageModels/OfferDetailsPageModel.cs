using Lando.ApiModels.Offers;
using Lando.ApiModels.Products;
using Lando.Services;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lando.PageModels
{
    public class OfferDetailsPageModel : BasePageModel, IQueryAttributable
    {
        private string offerId;
        private readonly IApiService apiService;

        public OfferDetailsPageModel(IApiService apiService)
        {
            this.apiService = apiService;

        }

        public string Title { get; set; }
        
        public OfferDetailsResponseModel Offer { get; set; }

        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query.TryGetValue("offerId", out string offerId))
            {
                this.offerId = offerId;
                await LoadProductsAsync();
            }

        }

        private async Task LoadProductsAsync()
        {
            var products = await apiService.GetOfferDetailsAsync(offerId);

            if (products.Success)
            {
                Offer = products.Entity;
            }
        }


        public override async Task InitializeAsync()
        {
            Title = "Szczególy produktu";
        }
    }
}
