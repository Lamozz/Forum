using AutoMapper;
using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Category;
using Forum.Common.Dtos.Theme;
using Forum.Common.Exeptions;
using Forum.Dal.Interfaces;
using Forum.Domain;

namespace Forum.Bll.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Theme> _repository;

        public ThemeService(IRepository<Theme> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<ThemeDto>> GetThemesAsync()
        {
            var themes = await _repository.GetAllAsync();

            return _mapper.Map<IList<Theme>, IList<ThemeDto>>(themes);
        }
        public async Task<ThemeDto> GetThemeByIdAsync(int id)
        {
            var theme = await _repository.GetByIdAsync(id);

            if (theme is null)
            {
                throw new NotFoundException("Theme isn't exists.");
            }
            return _mapper.Map<Theme, ThemeDto>(theme);
        }
        public async Task<ThemeDto> CreateThemeAsync(ThemeUpdateDto themeUpdateDto)
        {
            var theme = _mapper.Map<Theme>(themeUpdateDto);

            await _repository.CreateAsync(theme);

            await _repository.SaveChangesAsync();

            return _mapper.Map<Theme, ThemeDto>(theme);
        }
        public async Task<ThemeDto> UpdateThemeAsync(int id, ThemeUpdateDto themeUpdateDto)
        {
            var theme = await _repository.GetByIdAsync(id);

            if (theme is null)
            {
                throw new NotFoundException("Not Found");
            }
            _mapper.Map(themeUpdateDto, theme);

            await _repository.SaveChangesAsync();

            return _mapper.Map<Theme, ThemeDto>(theme);
        }

        public async Task DeleteThemeAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);

            await _repository.SaveChangesAsync();
        }
    }
}
