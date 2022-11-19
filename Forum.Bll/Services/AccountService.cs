using AutoMapper;
using Forum.Bll.Interfaces;
using Forum.Common.Dtos.User;
using Forum.Common.Exeptions;
using Forum.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Forum.Bll.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> RegisterUserAsync(UserRegisterDto userRegisterDto)
        {
            var user = _mapper.Map<UserRegisterDto, User>(userRegisterDto);

            var identityResult = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (!identityResult.Succeeded)
            {
                throw new ConflictException("This user already exists");
            }

            return true;
        }

        public async Task<string> LoginUserAsync(UserLoginDto userLoginDto,
            (string Token, string Audience, string Issuer) authOptions)
        {

            var signResult = await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);

            if (!signResult.Succeeded)
            {
                throw new NotFoundException("User not found");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Token));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userLoginDto.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                audience: authOptions.Audience,
                issuer: authOptions.Issuer,
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
