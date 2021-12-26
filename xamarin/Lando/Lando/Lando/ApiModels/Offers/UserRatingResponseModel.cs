using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lando.ApiModels.Offers
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AverageRates
    {
        [JsonProperty("delivery")]
        public double Delivery { get; set; }

        [JsonProperty("deliveryCost")]
        public double DeliveryCost { get; set; }

        [JsonProperty("description")]
        public double Description { get; set; }

        [JsonProperty("service")]
        public double Service { get; set; }
    }

    public class NotRecommended
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("unique")]
        public int Unique { get; set; }
    }

    public class Recommended
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("unique")]
        public int Unique { get; set; }
    }

    public class UserRatingResponseModel
    {
        [JsonProperty("averageRates")]
        public AverageRates AverageRates { get; set; }

        [JsonProperty("notRecommended")]
        public NotRecommended NotRecommended { get; set; }

        [JsonProperty("recommended")]
        public Recommended Recommended { get; set; }

        [JsonProperty("recommendedPercentage")]
        public string RecommendedPercentage { get; set; }
    }


}
