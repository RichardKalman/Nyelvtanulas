using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.DTOs;
using Server.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    
    public class LessonResultController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly ILessonResultRepository _lessonResultRepository;

        public LessonResultController(IMapper mapper, ILessonRepository lessonRepository, ILessonResultRepository lessonResultRepository)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
            _lessonResultRepository = lessonResultRepository;
        }
        [HttpPost]
        public async Task<ActionResult<LessonResultDto>> AddResult(LessonResultRequestDto dto) 
        {
            if(dto == null)
            {
                return BadRequest("Nem küldtél adatot");
            }

            if(dto.words.Count == 0)
            {
                return BadRequest("Nem küldtél szavakat ellenőrzésre");
            }

            var lesson = await _lessonRepository.GetLessonByIdAsync(dto.lessonId);
            if(lesson == null)
            {
                return BadRequest("Nincs ilyen lecke!");
            }

            var lessonResult = await _lessonResultRepository.AddResultAsync(dto);
            if(lessonResult != null)
            {
                return Ok(lessonResult);
            }
            return Ok("Kiskutya");
        }

        [HttpGet]
        public async Task<ActionResult<LessonResultDto>> GetAll()
        {
            return Ok(await _lessonResultRepository.GetAll());
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<LessonResultDto>> GetAllbyUserId(int id)
        {
            return Ok(await _lessonResultRepository.GetByUserId(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LessonResultDto>> GetAllByLessonResultId(int id)
        {
            return Ok(await _lessonResultRepository.GetById(id));
        }


    }
}
