using Lando.ApiModels;
using Lando.Services;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lando.PageModels
{
    public class BrowsePageModel : BasePageModel
    {
        private readonly IApiService apiService;

        public BrowsePageModel(IApiService apiService)
        {
            this.apiService = apiService;
            CategorySelectedCommand = new AsyncCommand<CategoryItemModel>(CategorySelectedAsync);
            CategoryBackCommand = new Xamarin.Forms.Command(CategoryBack);
            ShowProductsCommand = new AsyncCommand(ShowProductsAsync);
            GoToSearchCommand = new AsyncCommand(GoToSearchAsync);
        }

        public List<CategoryItemModel> Categories { get; set; }
        public CategoryItemModel SelectedCategory { get; set; }
        public bool IsBackCategoryButtonVisible { get; set; }
        public IAsyncCommand<CategoryItemModel> CategorySelectedCommand { get; }
        public ICommand CategoryBackCommand { get; }
        public ICommand ShowProductsCommand { get; }
        public IAsyncCommand GoToSearchCommand { get; }

        public override async Task InitializeAsync()
        {
            var response = await apiService.GetCategoriesAsync();

            if (response.Failed)
            {
                return;
            }

            Categories = response.Entity.Categories;

        }
        private async Task CategorySelectedAsync(CategoryItemModel selectedCategory)
        {
            SelectedCategory = selectedCategory;
            if (SelectedCategory.Leaf)
            {
                // TODO go to product list

                return;
            }

            if (SelectedCategory.SubCategories == null)
            {
                var response = await apiService.GetCategoriesAsync(SelectedCategory.Id);

                if (response.Failed)
                {
                    return;
                }

                SelectedCategory.SubCategories = response.Entity.Categories;
                SelectedCategory.SubCategories.ForEach(x =>
                { 
                    x.ParentCategoriesList = Categories;
                    x.ParentCategory = SelectedCategory;
                });
            }

            IsBackCategoryButtonVisible = true;

            Categories = SelectedCategory.SubCategories;
           
        }


        private async Task ShowProductsAsync()
        {
            await AppShell.Current.GoToAsync($"/productdetails?category={SelectedCategory.Id}");
        }

        private void CategoryBack()
        {
            SelectedCategory = SelectedCategory.ParentCategory;
            Categories = Categories.FirstOrDefault().ParentCategoriesList;
            if (Categories?.FirstOrDefault()?.ParentCategoriesList == null)
            {
                IsBackCategoryButtonVisible = false;
            }
        }

        private async Task GoToSearchAsync()
        {
            await AppShell.Current.GoToAsync("/productdetails?search=true");
        }

    }
}
