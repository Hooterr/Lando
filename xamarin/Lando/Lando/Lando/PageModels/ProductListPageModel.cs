using Lando.ApiModels.Offers;
using Lando.ApiModels.Products;
using Lando.Services;
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
    public class ProductListPageModel : BasePageModel, IQueryAttributable
    {
        private string categoryId;
        private readonly IApiService apiService;

        public ProductListPageModel(IApiService apiService)
        {
            this.apiService = apiService;
            ItemSelectedCommand = new AsyncCommand<OfferItemModel>(ItemSelectedAsync);
            SearchCommand = new AsyncCommand(LoadProductsAsync);
            RemoveCategoryFilterCommand = new Xamarin.Forms.Command(RemoveCategoryFilter);
        }


        public string Title { get; set; }
        public string SearchText { get; set; }
        public string CurrentCategory { get; set; }
        public bool IsCategoryFilterVisible => !string.IsNullOrEmpty(categoryId);
        public List<OfferItemModel> Offers { get; set; }
        public IAsyncCommand<OfferItemModel> ItemSelectedCommand { get; }
        public IAsyncCommand SearchCommand { get; }
        public ICommand RemoveCategoryFilterCommand { get; }

        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query.TryGetValue("category", out string category))
            {
                categoryId = category;
                await LoadProductsAsync();
            }
        }

        private async Task LoadProductsAsync()
        {
            var products = await apiService.GetProductsAsync(x =>
            {
                x.CategoryId = categoryId;
                x.SearchPhrase = SearchText;
            });

            if (products.Success)
            {
                CurrentCategory = products.Entity.Categories.Path.LastOrDefault()?.Name;
                Offers = products.Entity.Items.Regular;
            }
        }

        public override async Task InitializeAsync()
        {
            Title = "Lista produktów";
        }

        private async Task ItemSelectedAsync(OfferItemModel item)
        {
            await Shell.Current.GoToAsync($"/offerdetails?offerId={item.Id}");
        }

        private void RemoveCategoryFilter()
        {
            CurrentCategory = null;
            categoryId = null;
        }
    }
}
