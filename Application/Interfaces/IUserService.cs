using Application.DTOs.Account;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task SignOutAsync();
        Task<RegisterResponse> RegisterAsync(string rol, SaveUserViewModel userVm, string origin = "");
        Task<UserViewModel> GetUserById(string id);
        Task<List<UserViewModel>> GetAllUsers();
        Task ChangeProjectAsync(UserViewModel vm);
    }
}
