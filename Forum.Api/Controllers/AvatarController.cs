using Forum.Bll.Interfaces;
using Forum.Dal.Interfaces;
using Forum.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/avatar")]
    public class AvatarController : ApplicationControllerBase
    {
        private readonly IRepository<Avatar> repository;

        public AvatarController(IRepository<Avatar> repository)
        {
            this.repository = repository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAvatar([FromRoute] int userId)
        {
            var avatar = await repository.GetByIdAsync(userId);

            if (avatar is null)
            {
                return BadRequest();
            }

            var contentType = "APPLICATION/octet-stream";

            return File(avatar.Image, contentType, avatar.ImageName);
        }

        [HttpPost("{userId}")]
        public async Task CreateAvatar([FromForm] IFormFile avatar, [FromRoute] int userId)
        {
            var image = new Avatar();
            using (MemoryStream ms = new MemoryStream())
            {
             
                await avatar.CopyToAsync(ms);
                image.Image = ms.ToArray();
                image.Id = userId;
                image.ImageName = avatar.Name;
            }

            await repository.CreateAsync(image);
            await repository.SaveChangesAsync();
        }

        [HttpPut("{userId}")]
        public async Task UpdateAvatar([FromForm] IFormFile avatar, [FromRoute] int userId)
        {
            var image = await repository.GetByIdAsync(userId);

            using (MemoryStream ms = new MemoryStream())
            {

                await avatar.CopyToAsync(ms);
                image.Image = ms.ToArray();
                image.ImageName = avatar.Name;
            }

            await repository.SaveChangesAsync();
        }
    }
}
