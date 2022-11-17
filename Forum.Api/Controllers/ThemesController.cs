using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Theme;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/themes")]
    public class ThemesController : ApplicationControllerBase
    {
        private readonly IThemeService _themeService;

        public ThemesController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetThemes()
        {
            var themes = await _themeService.GetThemesAsync();

            return Ok(themes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTheme(int id)
        {
            var theme = await _themeService.GetThemeByIdAsync(id);

            return Ok(theme);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTheme([FromBody] ThemeUpdateDto themeUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var theme = await _themeService.CreateThemeAsync(themeUpdateDto);

            return CreatedAtAction(nameof(GetTheme), new { id = theme.Id }, theme);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTheme(int id, [FromBody] ThemeUpdateDto themeUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var themeDto = await _themeService.UpdateThemeAsync(id, themeUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheme(int id)
        {
            await _themeService.DeleteThemeAsync(id);

            return NoContent();
        }
    }
}
