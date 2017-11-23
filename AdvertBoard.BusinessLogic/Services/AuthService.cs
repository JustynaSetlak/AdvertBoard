using System.Threading.Tasks;
using AdvertBoard.BusinessLogic.IdentityConfig;
using AdvertBoard.DbAccess.Models;
using AdvertBoard.Dtos;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace AdvertBoard.BusinessLogic.Services
{
    public class AuthService
    {
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;
        private readonly IMapper _mapper;
        public AuthService(ApplicationSignInManager signInManager, ApplicationUserManager userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<SignInStatus> PasswordSignInAsync(string email, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, false);
        }

        public async Task<IdentityResult> CreateAsync(RegisterUserDto registerUserDto)
        {
            var user = _mapper.Map<RegisterUserDto, User>(registerUserDto);
            return await _userManager.CreateAsync(user, registerUserDto.Password);
        }
    }
}