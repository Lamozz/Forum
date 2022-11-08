using AutoMapper;
using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Section;
using Forum.Common.Exeptions;
using Forum.Dal.Interfaces;
using Forum.Domain;

namespace Forum.Bll.Services
{
    public class SectionService : ISectionService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Section> _repository;

        public SectionService(IRepository<Section> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<SectionDto>> GetSectionsAsync()
        {
            var sections = await _repository.GetAllAsync();
            return sections.Select(sections => _mapper.Map<Section, SectionDto>(sections)).ToList();
        }
        public async Task<SectionDto> GetSectionByIdAsync(int id)
        {
            var section = await _repository.GetByIdAsync(id);

            if (section is null)
            {
                throw new NotFoundException("Section isn't exists.");
            }
            return _mapper.Map<Section, SectionDto>(section);
        }
        public async Task<SectionDto> CreateSectionAsync(SectionUpdateDto sectionUpdateDto)
        {
            var section = _mapper.Map<Section>(sectionUpdateDto);

            await _repository.CreateAsync(section);

            return _mapper.Map<Section, SectionDto>(section);
        }
        public async Task<SectionDto> UpdateSectionAsync(int id, SectionUpdateDto sectionUpdateDto)
        {
            var section = await _repository.GetByIdAsync(id);

            if (section is null)
            {
                throw new NotFoundException("Not Found");
            }
            _mapper.Map(sectionUpdateDto, section);

            await _repository.UpdateAsync(section);

            return _mapper.Map<Section, SectionDto>(section);
        }

        public async Task DeleteSectionAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}
