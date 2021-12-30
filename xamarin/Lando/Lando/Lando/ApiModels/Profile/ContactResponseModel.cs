using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lando.ApiModels.Profile
{
    public class Email
    {
        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public class Phone
    {
        [JsonProperty("number")]
        public string Number { get; set; }
    }

    public class Contact
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("emails")]
        public List<Email> Emails { get; set; }

        [JsonProperty("phones")]
        public List<Phone> Phones { get; set; }
    }

    public class ContactResponseModel
    {
        [JsonProperty("contacts")]
        public List<Contact> Contacts { get; set; }
    }

}
