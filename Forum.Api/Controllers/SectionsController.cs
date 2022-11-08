﻿using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Section;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/sections")]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionsController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSections()
        {
            var sections = await _sectionService.GetSectionsAsync();

            return Ok(sections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSection(int id)
        {
            var section = await _sectionService.GetSectionByIdAsync(id);

            return Ok(section);
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

            var sectionDto = await _sectionService.UpdateSectionAsync(id, sectionUpdateDto);

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