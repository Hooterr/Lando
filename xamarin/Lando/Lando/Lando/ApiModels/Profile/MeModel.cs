using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lando.ApiModels
{
    public class MeModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }


        // TODO company

    }
}
