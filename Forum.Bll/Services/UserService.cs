using AutoMapper;
using Forum.Bll.Interfaces;
using Forum.Common.Dtos.User;
using Forum.Common.Exeptions;
using Forum.Dal.Interfaces;
using Forum.Domain;

namespace Forum.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<UserDto>> GetUsersAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(users => _mapper.Map<User, UserDto>(users)).ToList();
        }
        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
            {
                throw new NotFoundException("User isn't exists.");
            }
            return _mapper.Map<User, UserDto>(user);
        }
        public async Task<UserDto> CreateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);

            await _repository.CreateAsync(user);

            return _mapper.Map<User, UserDto>(user);
        }
        public async Task<UserDto> UpdateUserAsync(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
            {
                throw new NotFoundException("Not Found");
            }
            _mapper.Map(userUpdateDto, user);

            await _repository.UpdateAsync(user);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}
