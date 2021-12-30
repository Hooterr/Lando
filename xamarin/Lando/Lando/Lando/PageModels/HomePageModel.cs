using Lando.ApiModels.Offers;
using Lando.Database.Services;
using Lando.Services;
using Lando.Utils;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Lando.PageModels
{
    public class HomePageModel : BasePageModel
    {
        private readonly IApiService api;
        private readonly ICartDbService cartDbService;

        public HomePageModel(IApiService api, ICartDbService cartDbService)
        {
            this.api = api;
            this.cartDbService = cartDbService;
            GoToCartCommand = new AsyncCommand(GoToCartAsync);
            GoToOffersCommand = new AsyncCommand(GoToOffersAsync);
            RefreshCommand = new AsyncCommand(RefreshAsync);
            FeaturedItemSelectedCommand = new AsyncCommand<OfferItemModel>(FeaturedItemSelectedAsync);
        }

        public int CartCount { get; set; }
        public double CartValue { get; set; }
        public bool CartHasItems { get; set; }
        public string Name { get; set; }
        public string WaitingPolishPlurar => Helpers.PolishPlural(CartCount, "czeka", "czekają", "czekają");
        public List<OfferItemModel> FeaturedOffers { get; set; }
        public string FeaturedCategoryName { get; set; }
        public bool IsRefreshing { get; set; }

        public override async Task InitializeAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var allItems = cartDbService.All().ToList();
            CartCount = allItems.Sum(x => x.Quantity);
            CartValue = allItems.Sum(x => x.Quantity * double.Parse(x.Offer.SellingMode.Price.Amount));
            var me = await api.GetMeAsync();
            Name = $"{me.Entity.FirstName} {me.Entity.LastName}";

            var rng = new Random();
            var categories = await api.GetCategoriesAsync();
            var maxCount = categories.Entity.Categories.Count;
            var rootCat = categories.Entity.Categories[rng.Next(0, maxCount)];
            categories = await api.GetCategoriesAsync(rootCat.Id);
            maxCount = categories.Entity.Categories.Count;
            var featuredCategory = categories.Entity.Categories[rng.Next(0, maxCount)];
            var items = await api.GetProductsAsync(x =>
            {
                x.CategoryId = featuredCategory.Id;
                x.Limit = 10;
            });

            FeaturedOffers = items.Entity.Items.Promoted.Concat(items.Entity.Items.Regular).ToList();
            FeaturedCategoryName = featuredCategory.Name;
        }

        public IAsyncCommand GoToOffersCommand { get; }
        public IAsyncCommand GoToCartCommand { get; }
        public IAsyncCommand RefreshCommand { get; }
        public IAsyncCommand<OfferItemModel> FeaturedItemSelectedCommand { get; }


        private async Task GoToOffersAsync()
        {
            await Shell.Current.GoToAsync("//browse");
        }

        private async Task GoToCartAsync()
        {
            Helpers.PolishPlural(CartCount, "produkt", "produkty", "produktów");

            await Shell.Current.GoToAsync("//cart");
        }

        private async Task RefreshAsync()
        {
            IsRefreshing = true;
            await LoadDataAsync();
            IsRefreshing = false;

        }
        
        private async Task FeaturedItemSelectedAsync(OfferItemModel item)
        {
            OfferDetailsPageModel.Parameter = item;
            await Shell.Current.GoToAsync($"/offerdetails?offerId={item.Id}");
        }
    }
}
