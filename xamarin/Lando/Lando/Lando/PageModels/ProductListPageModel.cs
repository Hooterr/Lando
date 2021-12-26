using Lando.ApiModels.Offers;
using Lando.ApiModels.Products;
using Lando.Services;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lando.PageModels
{
    public class GroupedProducts : List<OfferItemModel>
    {
        public string Name { get; set; }
        public GroupedProducts(string name, List<OfferItemModel> items) : base(items)
        {
            Name = name;
        }
    }

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
        public List<GroupedProducts> Offers { get; set; }
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
                var offers = new List<GroupedProducts>();

                if (products.Entity.Items.Promoted?.Any() ?? false)
                {
                    offers.Add(new GroupedProducts("Oferty promowane", products.Entity.Items.Promoted));
                }

                if (products.Entity.Items.Regular?.Any() ?? false)
                {
                    offers.Add(new GroupedProducts("Oferty", products.Entity.Items.Regular));
                }

                Offers = offers;
            }
        }

        public override async Task InitializeAsync()
        {
            Title = "Lista produktów";
        }

        private async Task ItemSelectedAsync(OfferItemModel item)
        {
            OfferDetailsPageModel.Parameter = item;
            await Shell.Current.GoToAsync($"/offerdetails?offerId={item.Id}");
        }

        private void RemoveCategoryFilter()
        {
            CurrentCategory = null;
            categoryId = null;
        }
    }
}
