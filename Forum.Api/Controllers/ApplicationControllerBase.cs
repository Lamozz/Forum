using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class ApplicationControllerBase : ControllerBase
    {
    }
}
