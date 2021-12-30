﻿using Lando.ApiModels;
using Lando.ApiModels.Offers;
using Lando.ApiModels.Products;
using Lando.ApiModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lando.Services
{
    public interface IApiService
    {
        Task<ApiResonseModel<CategoriesModel>> GetCategoriesAsync(string parentId = null);
        Task<ApiResonseModel<MeModel>> GetMeAsync();
        Task<ApiResonseModel<OfferDetailsResponseModel>> GetOfferDetailsAsync(string id);
        Task<ApiResonseModel<OffersResponseModel>> GetProductsAsync(Action<GetOffersParameters> action);
        Task<ApiResonseModel<UserRatingResponseModel>> GetUserRating(string userId);
        Task<ApiResonseModel<ContactResponseModel>> GetContactsAsync();
        Task<ApiResonseModel<ApiModels.Profile.Contact>> AddContactAsync(ApiModels.Profile.Contact contact);
        Task<ApiResonseModel<ApiModels.Profile.Contact>> ChangeContactAsync(ApiModels.Profile.Contact contact);

    }
}