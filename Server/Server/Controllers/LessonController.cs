using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Data;
using Server.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;
using AutoMapper;
using Server.DTOs;
using System.Security.Claims;

namespace Server.Controllers
{
    [Authorize]
    public class LessonController : BaseApiController
    {
        private readonly ILessonWordRepository _lessonWordRepository;
        private readonly IWordRepository _wordRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public LessonController(ILessonWordRepository lessonWordRepository, IWordRepository wordRepository, ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonWordRepository = lessonWordRepository;
            _wordRepository = wordRepository;
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDto>>> Getlessons()
        {
            var lessons = await _lessonRepository.GetLessonsAsync();
            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LessonDto>> GetLessonById(int id)
        {
            var lesson = await _lessonRepository.GetLessonByIdAsync(id);
            // var dto = _mapper.Map<LessonDto>(lesson);
            return Ok(lesson);
        }

        [HttpPut]
        public async Task<ActionResult> ActionResult(UpdateLessonDto dto)
        {

            //wip ellenőrzések
            var lesson = await _lessonRepository.GetLessonByIdAsLessonAsync(dto.Id);

            await _lessonWordRepository.DeleteAllByLessonId(lesson.Id);
            await _lessonWordRepository.AddAllWordByLessonId(dto.Id, dto.WordIds);

            _mapper.Map(dto, lesson);

            //var lesson = _mapper.Map<Lesson>(lessonDto);

            _lessonRepository.Update(lesson);


            if (await _lessonRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update word");


        }
        [HttpPost]
        public async Task<ActionResult<LessonDto>> AddLesson(AddLessonDto addLessonDto)
        {
            //WIP ELLENŐRZÉS
            var lesson = await _lessonRepository.AddLesson(addLessonDto);

            return lesson;

            //return BadRequest("Nem sikerült hozzáadni a Leckét");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLesson(int id)
        {
            await _lessonRepository.DeleteLessonById(id);
            return NoContent();
        }

        [HttpGet("availableusers/{id}")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetNoAcceptUsers(int id)
        {
            return Ok(await _lessonRepository.GetNoAcceptUsers(id));
        }


        
    }
}
