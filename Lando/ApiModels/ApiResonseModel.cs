using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lando.ApiModels
{
    public record ApiResonseModel<TReponse>
    {
        public bool Success { get; set; }
        public bool Failed => !Success;

        public TReponse Entity { get; set; }

    }
}
