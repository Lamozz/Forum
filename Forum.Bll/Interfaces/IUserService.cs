using Forum.Common.Dtos.Theme;
using Forum.Common.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Bll.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(string id);
        Task<UserDto> UpdateUserAsync(string id, UserUpdateDto UserUpdateDto);
    }
}
