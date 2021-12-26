using Lando.Database.Models;
using Lando.Database.Services;
using Lando.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lando.PageModels
{
    public class CartPageModel : BasePageModel
    {
        private readonly ICartDbService _cartDbService;
        private readonly IApiService _api;

        public ICommand RemoveCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }

        public double TotalPrice { get; set; }

        public CartPageModel(ICartDbService cartDbService, IApiService api)
        {
            _cartDbService = cartDbService;
            _api = api;
            RemoveCommand = new Command<CartOfferModel>(RemoveFromCart);
            AddCommand = new Command<CartOfferModel>(IncrementQuantity);
            SubtractCommand = new Command<CartOfferModel>(DecrementQuantity);
        }

        public ObservableCollection<CartOfferModel> Cart { get; set; }

        private void RemoveFromCart(CartOfferModel item)
        {
            _cartDbService.Delete(item);
            Cart.Remove(item);
            CalculateTotal();
        }

        private void IncrementQuantity(CartOfferModel item)
        {
            if (item.Offer.Stock.Available > item.Quantity)
            {
                item.Quantity++;
                _cartDbService.Update(item);
                CalculateTotal();
            }
        }

        private void DecrementQuantity(CartOfferModel item)
        {
            item.Quantity--;
            if (item.Quantity == 0)
            {
                RemoveFromCart(item);
            }
            else
            {
                _cartDbService.Update(item);
            }
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            TotalPrice = Cart.Sum(x => x.TotalPrice);
        }

        public override Task InitializeAsync()
        {
            LoadCart();

            MessagingCenter.Subscribe<Application>(this, "CartChanged", sender =>
            {
                LoadCart();
            });

            return Task.CompletedTask;
        }

        private void LoadCart()
        {
            Cart = new ObservableCollection<CartOfferModel>(_cartDbService.All());
            CalculateTotal();
        }
    }
}
