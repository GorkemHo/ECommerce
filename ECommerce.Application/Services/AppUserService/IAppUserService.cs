using ECommerce.Application.Models.DTOs.CategortyDto;
using ECommerce.Application.Models.DTOs.UserDto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.AppUserService
{
    public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDto model);
        Task<SignInResult> Login(LoginDto model);
        Task LogOut();
        Task Delete(string id);
        Task UpdateUser(UpdateProfileDto model);
        Task<UpdateProfileDto> GetByUserName(string userName);
        Task<bool> UserInRole(string userName, string role);
        Task<List<UpdateProfileDto>> GetAllUsers();
        Task<UpdateProfileDto> GetUserById(string id);
        Task<IdentityResult> CreateUserByAdmin(RegisterDto model);



    }
}
