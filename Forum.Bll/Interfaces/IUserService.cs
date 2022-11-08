using Forum.Common.Dtos.User;

namespace Forum.Bll.Interfaces
{
    public interface IUserService
    {
        Task<IList<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(UserUpdateDto UserUpdateDto);
        Task<UserDto> UpdateUserAsync(int id, UserUpdateDto UserUpdateDto);
        Task DeleteUserAsync(int id);
    }
}
