using Lando.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lando.Services
{
    public interface IApiService
    {
        Task<ApiResonseModel<CategoriesModel>> GetCategories();
    }
}
