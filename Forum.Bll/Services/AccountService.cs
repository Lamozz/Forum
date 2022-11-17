using AutoMapper;
using Forum.Bll.Infrastructure;
using Forum.Bll.Interfaces;
using Forum.Common.Dtos.User;
using Forum.Common.Exeptions;
using Forum.Dal.Interfaces;
using Forum.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Forum.Bll.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public AccountService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> RegisterUserAsync(UserRegisterDto userRegisterDto)
        {
            var user = _mapper.Map<UserRegisterDto, User>(userRegisterDto);

            var alreadyExists = await _repository.GetByQueryAsync(u => u.UserName == user.UserName);

            if (alreadyExists.Any())
            {
                throw new ConflictException("User with this credentials exists");
            }

            var hash = Cryptography.HashString(user.Password);
            user.Password = hash.hashed;

            await _repository.CreateAsync(user);

            return true;
        }

        public async Task<string> LoginUserAsync(UserLoginDto userLoginDto,
            (string Token, string Audience, string Issuer) authOptions)
        {
            var user = (await _repository
                .GetByQueryAsync(
                    u => u.UserName == userLoginDto.UserName))
                .FirstOrDefault();

            if (user is null)
            {
                throw new NotFoundException("User with this credentials not found");
            }


            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Token));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
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
