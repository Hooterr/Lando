using Lando.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lando.PageModels
{
    public class HomePageModel : BasePageModel
    {
        private readonly IApiService api;

        public HomePageModel(IApiService api)
        {
            this.api = api;
        }

        public string JsonContent { get; set; }

        public override async Task InitializeAsync()
        {
            var response = await api.GetCategoriesAsync();
            if (response.Success)
            {
                JsonContent = JsonConvert.SerializeObject(response.Entity, Formatting.Indented);
            }
        }
    }
}
