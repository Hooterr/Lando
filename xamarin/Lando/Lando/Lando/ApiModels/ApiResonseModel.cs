using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lando.ApiModels
{
    public class ApiResonseModel<TReponse>
    {
        public bool Success { get; set; }
        public bool Failed => !Success;

        public TReponse Entity { get; set; }

    }
}
