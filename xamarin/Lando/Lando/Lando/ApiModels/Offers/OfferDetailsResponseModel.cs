using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lando.ApiModels.Offers
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AdditionalServices
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class ImpliedWarranty
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class ReturnPolicy
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Warranty
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class AfterSalesServices
    {
        [JsonProperty("impliedWarranty")]
        public ImpliedWarranty ImpliedWarranty { get; set; }

        [JsonProperty("returnPolicy")]
        public ReturnPolicy ReturnPolicy { get; set; }

        [JsonProperty("warranty")]
        public Warranty Warranty { get; set; }
    }

    public class Attachment
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class CompatibilityList
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Contact
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class CustomParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public List<string> Values { get; set; }
    }

    public class ShippingRates
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Delivery
    {
        [JsonProperty("additionalInfo")]
        public string AdditionalInfo { get; set; }

        [JsonProperty("handlingTime")]
        public string HandlingTime { get; set; }

        [JsonProperty("shippingRates")]
        public ShippingRates ShippingRates { get; set; }

        [JsonProperty("shipmentDate")]
        public DateTime ShipmentDate { get; set; }
    }

    public class Item
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public List<string> Values { get; set; }
    }

    public class Section
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Description
    {
        [JsonProperty("sections")]
        public List<Section> Sections { get; set; }
    }

    public class WholesalePriceList
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Discounts
    {
        [JsonProperty("wholesalePriceList")]
        public WholesalePriceList WholesalePriceList { get; set; }
    }

    public class External
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class FundraisingCampaign
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Location
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }
    }

    public class RangeValue
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }

    public class Parameter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rangeValue")]
        public RangeValue RangeValue { get; set; }

        [JsonProperty("values")]
        public List<string> Values { get; set; }

        [JsonProperty("valuesIds")]
        public List<string> ValuesIds { get; set; }
    }

    public class Payments
    {
        [JsonProperty("invoice")]
        public string Invoice { get; set; }
    }

    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Promotion
    {
        [JsonProperty("bold")]
        public bool Bold { get; set; }

        [JsonProperty("departmentPage")]
        public bool DepartmentPage { get; set; }

        [JsonProperty("emphasized")]
        public bool Emphasized { get; set; }

        [JsonProperty("emphasizedHighlightBoldPackage")]
        public bool EmphasizedHighlightBoldPackage { get; set; }

        [JsonProperty("highlight")]
        public bool Highlight { get; set; }
    }

    public class Publication
    {
        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("endingAt")]
        public DateTime EndingAt { get; set; }

        [JsonProperty("startingAt")]
        public DateTime StartingAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("endedBy")]
        public string EndedBy { get; set; }

        [JsonProperty("republish")]
        public bool Republish { get; set; }
    }

    public class Price
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class MinimalPrice
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class StartingPrice
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class NetPrice
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class DetailsSellingMode
    {
        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("minimalPrice")]
        public MinimalPrice MinimalPrice { get; set; }

        [JsonProperty("startingPrice")]
        public StartingPrice StartingPrice { get; set; }

        [JsonProperty("netPrice")]
        public NetPrice NetPrice { get; set; }
    }

    public class Tax
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("exemption")]
        public string Exemption { get; set; }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }
    }

    public class SizeTable
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Stock
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public class TecdocSpecification
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Error
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("userMessage")]
        public string UserMessage { get; set; }
    }

    public class Warning
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("userMessage")]
        public string UserMessage { get; set; }
    }

    public class Validation
    {
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }

        [JsonProperty("warnings")]
        public List<Warning> Warnings { get; set; }

        [JsonProperty("validatedAt")]
        public DateTime ValidatedAt { get; set; }
    }

    public class OfferDetailsResponseModel
    { 
        [JsonProperty("additionalServices")]
        public AdditionalServices AdditionalServices { get; set; }

        [JsonProperty("afterSalesServices")]
        public AfterSalesServices AfterSalesServices { get; set; }

        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("compatibilityList")]
        public CompatibilityList CompatibilityList { get; set; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("customParameters")]
        public List<CustomParameter> CustomParameters { get; set; }

        [JsonProperty("delivery")]
        public Delivery Delivery { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("discounts")]
        public Discounts Discounts { get; set; }

        [JsonProperty("external")]
        public External External { get; set; }

        [JsonProperty("fundraisingCampaign")]
        public FundraisingCampaign FundraisingCampaign { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }

        [JsonProperty("payments")]
        public Payments Payments { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("promotion")]
        public Promotion Promotion { get; set; }

        [JsonProperty("publication")]
        public Publication Publication { get; set; }

        [JsonProperty("sellingMode")]
        public DetailsSellingMode SellingMode { get; set; }

        [JsonProperty("tax")]
        public Tax Tax { get; set; }

        [JsonProperty("sizeTable")]
        public SizeTable SizeTable { get; set; }

        [JsonProperty("stock")]
        public Stock Stock { get; set; }

        [JsonProperty("tecdocSpecification")]
        public TecdocSpecification TecdocSpecification { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("validation")]
        public Validation Validation { get; set; }
    }


}
