﻿using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Category;
using Forum.Common.Dtos.Section;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/sections")]
    public class SectionsController : ApplicationControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionsController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        public async Task<IList<SectionDto>> GetSections()
        {
            var sections = await _sectionService.GetSectionsAsync();

            return sections;
        }

        [HttpGet("{id}")]
        public async Task<SectionDto> GetSection(int id)
        {
            var section = await _sectionService.GetSectionByIdAsync(id);

            return section;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSection([FromBody] SectionUpdateDto sectionUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var section = await _sectionService.CreateSectionAsync(sectionUpdateDto);

            return CreatedAtAction(nameof(GetSection), new { id = section.Id }, section);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSection(int id, [FromBody] SectionUpdateDto sectionUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sectionService.UpdateSectionAsync(id, sectionUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            await _sectionService.DeleteSectionAsync(id);

            return NoContent();
        }
    }
}
