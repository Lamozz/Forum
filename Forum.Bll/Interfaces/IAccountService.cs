using Forum.Common.Dtos.User;

namespace Forum.Bll.Interfaces
{
    public interface IAccountService
    {
        Task<bool> RegisterUserAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginUserAsync(UserLoginDto userLoginDto, (string Token, string Audience, string Issuer) authOptions);
    }
}
