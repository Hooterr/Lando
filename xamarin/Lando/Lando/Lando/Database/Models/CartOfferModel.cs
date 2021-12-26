using Lando.ApiModels.Offers;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lando.Database.Models
{
    public class CartOfferModel : BaseDbModel
    {
        public OfferItemModel Offer { get; set; }
        public int Quantity { get; set; }

        [BsonIgnore]
        public double TotalPrice => Quantity * double.Parse(Offer.SellingMode.Price.Amount);

    }
}
