using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Theme;
using Forum.Common.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ApplicationControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{id}")]
        public async Task<UserDto> GetUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            return user;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserUpdateDto userUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.UpdateUserAsync(id, userUpdateDto);

            return NoContent();
        }

    }
}
