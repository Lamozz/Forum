using AutoMapper;
using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Theme;
using Forum.Common.Dtos.User;
using Forum.Common.Exeptions;
using Forum.Dal.Interfaces;
using Forum.Domain;
using Forum.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Forum.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _repository;

        public UserService(UserManager<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await _repository.FindByIdAsync(id) ;

            if (user is null)
            {
                throw new NotFoundException("User isn't exists.");
            }
            return _mapper.Map<User, UserDto>(user);
        }
        
        public async Task<UserDto> UpdateUserAsync(string id, UserUpdateDto userUpdateDto)
        {
            var user = await _repository.FindByIdAsync(id);

            if (user is null)
            {
                throw new NotFoundException("Not Found");
            }
            _mapper.Map(userUpdateDto, user);

            await _repository.UpdateAsync(user);

            return _mapper.Map<User, UserDto>(user);
        }
    }
}