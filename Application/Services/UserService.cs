using Application.DTOs.Account;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Helpers;
using Application.ViewModels;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse userViewModel;

        public UserService(IAccountService accountService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _accountService = accountService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            //userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel vm)
        {
            AuthenticationRequest loginRequest = _mapper.Map<AuthenticationRequest>(vm);
            AuthenticationResponse userResponse = await _accountService.AuthenticateAsync(loginRequest);
            return userResponse;
        }
        public async Task SignOutAsync()
        {
            await _accountService.SignOutAsync();
        }
        public async Task<RegisterResponse> RegisterAsync(string rol, SaveUserViewModel userVm, string origin = "")
        {
            RegisterRequest registerRequest = new();
            registerRequest = _mapper.Map<RegisterRequest>(userVm);

            if (string.IsNullOrEmpty(origin))
            {
                return await _accountService.RegisterUserAsync(registerRequest, rol);
            }
            return await _accountService.RegisterUserAsync(registerRequest, rol, origin);
        }

        public async Task<UserViewModel> GetUserById(string id)
        {
            var User = await _accountService.ListSingleUser(id);
            UserViewModel singleUser = _mapper.Map<UserViewModel>(User);
            return singleUser;
        }

        public async Task ChangeProjectAsync(UserViewModel vm)
        {
            await _accountService.ChangeProjectAsync(vm.Id, vm.ProjectId.Value);
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            var User = await _accountService.GetUsersAsync();
            List<UserViewModel> userList = _mapper.Map<List<UserViewModel>>(User);
            return userList.OrderBy(u => u.Firstname).OrderBy(u => u.Firstname).ToList();
        }


    }
}
