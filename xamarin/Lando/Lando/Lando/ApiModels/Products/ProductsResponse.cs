using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lando.ApiModels.Products
{
    public class ProductNextPage
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class ProductOptions
    {
        [JsonProperty("identifiesProduct")]
        public bool IdentifiesProduct { get; set; }
    }
    public class ProductRangeValue
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }

    public class ProductParameter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rangeValue")]
        public ProductRangeValue RangeValue { get; set; }

        [JsonProperty("values")]
        public List<string> Values { get; set; }

        [JsonProperty("valueIds")]
        public List<string> ValueIds { get; set; }

        [JsonProperty("valueLabels")]
        public List<string> ValueLabels { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("options")]
        public ProductOptions Options { get; set; }

    }
    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }

        [JsonProperty("parameters")]
        public List<ProductParameter> Parameters { get; set; }

    }
    public class ProductsResponse
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("nextPage")]
        public ProductNextPage NextPage { get; set; }
    }
}
