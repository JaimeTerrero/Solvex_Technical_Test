using Application.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task SignOutAsync();
        Task<RegisterResponse> RegisterUserAsync(RegisterRequest request, string rol, string origin = "");
        Task<List<UserList>> GetUsersAsync();
        Task<UserList> ListSingleUser(string id);
        Task ChangeProjectAsync(string userId, int newProject);
    }
}
