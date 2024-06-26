﻿using AutoMapper;
using ECommerce.Application.Models.DTOs.UserDto;
using ECommerce.Application.Services.CartService;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepo repo;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;
        private readonly ICartService cartService;
        public AppUserService(IAppUserRepo repo,
                              UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager,
                              IMapper mapper,
                              ICartService cartService)
        {
            this.repo = repo;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.cartService = cartService;
        }
        public async Task<UpdateProfileDto> GetByUserName(string userName)
        {
            var user = await repo.GetFilteredFirstOrDefault(
                                                            select:
                                                            x => mapper.Map<UpdateProfileDto>(x),
                                                            where:
                                                            x => x.UserName.Equals(userName) && !x.Status.Equals(Status.Passive));

            return user;
        }

        public async Task<SignInResult> Login(LoginDto model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            return result;
        }

        public async Task LogOut()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDto model)
        {
            var user = mapper.Map<AppUser>(model);

            var result = await userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
            }

            await cartService.CreateCart(user.Id);

            return result;
        }
        public async Task<IdentityResult> CreateUserByAdmin(RegisterDto model)
        {
            var user = mapper.Map<AppUser>(model);

            var result = await userManager.CreateAsync(user, model.Password);


        

            await cartService.CreateCart(user.Id);

            return result;
        }

        public async Task UpdateUser(UpdateProfileDto model)
        {
            var user = await repo.GetDefault(x => x.Id.Equals(model.Id));

            await userManager.RemovePasswordAsync(user);
            var task = await userManager.AddPasswordAsync(user, model.Password);

            await userManager.SetPhoneNumberAsync(user, model.PhoneNumber);

            await userManager.SetUserNameAsync(user, model.UserName);

            user.Address = model.Address;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            user.UpdateDate = DateTime.Now;

            await ImageUpload(model, user);
            await EmailUpdate(model, user);
            await UserNameUpdate(model, user);
        }

        private async Task UserNameUpdate(UpdateProfileDto model, AppUser user)
        {
            if (model.Password is not null)
            {
                var isUserNameExist = await userManager.FindByNameAsync(model.UserName.ToUpper());

                if (isUserNameExist is not null)
                {
                    await userManager.SetUserNameAsync(user, model.UserName);
                    //await signInManager.SignInAsync(user, false);
                }
            }
        }

        private async Task ImageUpload(UpdateProfileDto model, AppUser user)
        {
            if (model.UploadPath is not null)
            {
                using var image = Image.Load(model.UploadPath.OpenReadStream());
                image.Mutate(x => x.Resize(600, 560));
                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpg");
                user.ImagePath = $"/images/{guid}.jpg";

                await repo.UpdateAsync(user);
            }
        }

        private async Task EmailUpdate(UpdateProfileDto model, AppUser user)
        {
            if (model.Email is not null)
            {
                var isUserEmailExist = await userManager.FindByIdAsync(model.Id); 

                if (isUserEmailExist is not null)
                {
                    await userManager.SetEmailAsync(user, model.Email);
                }
            }
        }

        public async Task<bool> UserInRole(string userName, string role)
        {
            var user = await userManager.FindByNameAsync(userName);
            bool isInRole = await userManager.IsInRoleAsync(user, role);
            return isInRole;
        }
        public async Task<AppUser> AddRole(string userName, string role)
        {
            var user = await userManager.FindByNameAsync(userName);

            return user;
        }

        public async Task<List<UpdateProfileDto>> GetAllUsers()
        {
            var users = await repo.GetFilteredList(
                select: x => mapper.Map<UpdateProfileDto>(x),
                where: null
            );

            return users;
        }

        public async Task<UpdateProfileDto> GetUserById(string id)
        {
            var user = await repo.GetFilteredFirstOrDefault(select: x => mapper.Map<UpdateProfileDto>(x),
                                                             where: x => x.Id == id);
            return user;
        }

        public async Task Delete(string id)
        {

            var user = await repo.GetDefault(c => c.Id.Equals(id));

            if (user is not null)
            {
                user.DeleteDate = DateTime.Now;
                user.Status = Status.Passive;
                await repo.DeleteAsync(user);
            }
        }
    }
}
