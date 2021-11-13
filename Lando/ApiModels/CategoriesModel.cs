using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lando.ApiModels
{
    public class CategoriesModel
    {
        [JsonProperty("categories")]
        public List<CategoryItemModel> Categories { get; set; }
    }

    public class CategoryParentModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class CategoryItemModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("leaf")]
        public bool Leaf { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parent")]
        public CategoryParentModel Parent { get; set; }

        //TODO options

    }
}
