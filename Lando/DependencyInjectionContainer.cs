using Lando.PageModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lando
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services
                .AddTransient<BrowsePageModel>()
                .AddTransient<HomePageModel>()
                .AddTransient<CartPageModel>()
                .AddTransient<ProfilePageModel>();
            return services;
        }
    }
}
