using Lando.Database.Services;
using Lando.PageModels;
using Lando.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lando
{
    public static class DependencyInjectionContainer
    {
        public const string ClientId = "b73814aa969745c99e28fbb75edc99bb";
        public const string ClientSecretent = "tUvQlk3jWQiwapPcrzsnNFPnmEseuUHPRMjPZKQTDJLnrC2ApjcfvlsnIVbgkN2W";

        public static IServiceProvider Create()
        {
            return new ServiceCollection()
                .ConfigureServices()
                .BuildServiceProvider();
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services
                .AddSingleton<BrowsePageModel>()
                .AddTransient<HomePageModel>()
                .AddTransient<CartPageModel>()
                .AddTransient<ProfilePageModel>()
                .AddTransient<LoginWebPageModel>()
                .AddTransient<LoginStartPageModel>()
                .AddTransient<ProductListPageModel>()
                .AddTransient<OfferDetailsPageModel>()
                .AddTransient<LoadingPageModel>()
                .AddTransient<ProfileEditContactPageModel>()
                .AddSingleton<IApiService, ApiService>()
                .AddSingleton<ISessionManager, SessionManager>()
                .AddSingleton<ICartDbService, CartDbService>()
                .AddSingleton<IAuthenticationService, AuthenticationService>()
                .AddHttpClient("client_credentials", opt =>
                {
                    opt.BaseAddress = new Uri("https://allegro.pl.allegrosandbox.pl");
                    opt.DefaultRequestHeaders.Authorization
                        = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecretent}")));
                });
            services.AddHttpClient("api", opt =>
                {
                    opt.BaseAddress = new Uri("https://api.allegro.pl.allegrosandbox.pl");
                    opt.DefaultRequestHeaders.Accept.Clear();
                    opt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));
                });

                ;
            return services;
        }
    }
}
