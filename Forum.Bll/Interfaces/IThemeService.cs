using Forum.Common.Dtos.Theme;

namespace Forum.Bll.Interfaces
{
    public interface IThemeService
    {
        Task<IList<ThemeDto>> GetThemesAsync();
        Task<ThemeDto> GetThemeByIdAsync(int id);
        Task<ThemeDto> CreateThemeAsync(ThemeUpdateDto ThemeUpdateDto);
        Task<ThemeDto> UpdateThemeAsync(int id, ThemeUpdateDto ThemeUpdateDto);
        Task DeleteThemeAsync(int id);
    }
}
