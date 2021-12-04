using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lando.ApiModels.Offers
{
    public class SellerModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("company")]
        public bool Company { get; set; }

        [JsonProperty("superSeller")]
        public bool SuperSeller { get; set; }
    }

    public class PromotionModel
    {
        [JsonProperty("emphasized")]
        public bool Emphasized { get; set; }

        [JsonProperty("bold")]
        public bool Bold { get; set; }

        [JsonProperty("highlight")]
        public bool Highlight { get; set; }
    }

    public class LowestPriceModel
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class DeliveryModel
    {
        [JsonProperty("availableForFree")]
        public bool AvailableForFree { get; set; }

        [JsonProperty("lowestPrice")]
        public LowestPriceModel LowestPrice { get; set; }
    }

    public class ImageModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class PriceModel
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class FixedPriceModel
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class SellingMode
    {
        public string FormatText => Format switch
        {
            "BUY_NOW" => "Kup teraz",
            "AUCTION" => "Licytacja",
            "ADVERTISEMENT " => "Ogłoszenie",
            _ => "",
        };

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("price")]
        public PriceModel Price { get; set; }

        [JsonProperty("fixedPrice")]
        public FixedPriceModel FixedPrice { get; set; }

        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        [JsonProperty("popularityRange")]
        public string PopularityRange { get; set; }

        [JsonProperty("bidCount")]
        public int BidCount { get; set; }
    }

    public class StockModel
    {
        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("available")]
        public int Available { get; set; }
    }

    public class Vendor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class CategoryModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class PublicationModel
    {
        [JsonProperty("endingAt")]
        public DateTime EndingAt { get; set; }
    }

    public class OfferItemModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("seller")]
        public SellerModel Seller { get; set; }

        [JsonProperty("promotion")]
        public PromotionModel Promotion { get; set; }

        [JsonProperty("delivery")]
        public DeliveryModel Delivery { get; set; }

        [JsonProperty("images")]
        public List<ImageModel> Images { get; set; }

        [JsonIgnore]
        public string DisplayImage => Images?.FirstOrDefault()?.Url;

        [JsonProperty("sellingMode")]
        public SellingMode SellingMode { get; set; }

        [JsonProperty("stock")]
        public StockModel Stock { get; set; }

        [JsonProperty("vendor")]
        public Vendor Vendor { get; set; }

        [JsonProperty("category")]
        public CategoryModel Category { get; set; }

        [JsonProperty("publication")]
        public PublicationModel Publication { get; set; }
    }

    public class OfferItemsModel
    {
        [JsonProperty("promoted")]
        public List<OfferItemModel> Promoted { get; set; }

        [JsonProperty("regular")]
        public List<OfferItemModel> Regular { get; set; }
    }

    public class Subcategory
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class Path
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Categories
    {
        [JsonProperty("subcategories")]
        public List<Subcategory> Subcategories { get; set; }

        [JsonProperty("path")]
        public List<Path> Path { get; set; }
    }

    public class ValueModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("idSuffix")]
        public string IdSuffix { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }
    }

    public class FilterModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public List<ValueModel> Values { get; set; }

        [JsonProperty("minValue")]
        public int MinValue { get; set; }

        [JsonProperty("maxValue")]
        public int MaxValue { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public class SearchMeta
    {
        [JsonProperty("availableCount")]
        public int AvailableCount { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("fallback")]
        public bool Fallback { get; set; }
    }

    public class SortModel
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }
    }

    public class OffersResponseModel
    {
        [JsonProperty("items")]
        public OfferItemsModel Items { get; set; }

        [JsonProperty("categories")]
        public Categories Categories { get; set; }

        [JsonProperty("filters")]
        public List<FilterModel> Filters { get; set; }

        [JsonProperty("searchMeta")]
        public SearchMeta SearchMeta { get; set; }

        [JsonProperty("sort")]
        public List<SortModel> Sort { get; set; }
    }

}
