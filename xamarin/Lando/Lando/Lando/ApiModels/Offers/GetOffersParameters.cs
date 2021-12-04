using System;
using System.Collections.Generic;
using System.Text;

namespace Lando.ApiModels.Offers
{
    public class GetOffersParameters
    {
        public string SearchPhrase { get; set; }

        public string CategoryId { get; set; }

        public int? Offset { get; set; }

        public int? Limit { get; set; }
    }
}
