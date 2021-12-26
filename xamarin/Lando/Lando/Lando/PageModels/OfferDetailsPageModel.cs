using Lando.ApiModels.Offers;
using Lando.ApiModels.Products;
using Lando.Database.Models;
using Lando.Database.Services;
using Lando.Services;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lando.PageModels
{
    public class OfferDetailsPageModel : BasePageModel, IQueryAttributable
    {
        public static object Parameter { get; set; }
        public IAsyncCommand AddToCartCommand { get; }

        private readonly IApiService apiService;
        private readonly ICartDbService cart;

        public OfferDetailsPageModel(IApiService apiService, ICartDbService cart)
        {
            this.apiService = apiService;
            this.cart = cart;
            AddToCartCommand = new AsyncCommand(AddToCartAsync);
        }

        public string Title { get; set; }

        public OfferItemModel Offer { get; set; }

        public UserRatingResponseModel Rating { get; set; }

        public bool RatingVisible => Rating != null;

        public string Quantity { get; set; } = "1";


        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query.ContainsKey("offerId"))
            {
                Offer = Parameter as OfferItemModel;
                Parameter = null;
            }

            await LoadDetailsAsync();

        }

        private async Task LoadDetailsAsync()
        {
            var response = await apiService.GetUserRating(Offer.Seller.Id);
            if (response.Failed)
            {
                return;
            }

            Rating = response.Entity;
        }

        private async Task AddToCartAsync()
        {
            if (!int.TryParse(Quantity, out int qnt))
            {
                return;
            }

            if (qnt < 0 || qnt > Offer.Stock.Available)
            {
                // todo message
                return;
            }

            var existing = cart.All().FirstOrDefault(x => x.Offer.Id == Offer.Id);

            if (existing == null)
            {
                var newEntry = new CartOfferModel()
                {
                    Offer = Offer,
                    Quantity = qnt,
                };
                cart.Create(newEntry);
            }
            else
            {
                existing.Quantity = qnt;
                cart.Update(existing);
            }

            MessagingCenter.Send(Application.Current, "CartChanged");
        }

        public override async Task InitializeAsync()
        {
            Title = "Szczegóły produktu";
        }
    }
}
