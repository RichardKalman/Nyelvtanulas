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
    public class WordController : BaseApiController
    {
        private readonly IWordRepository _wordRepository;
        private readonly IMapper _mapper;

        public WordController(IWordRepository wordRepository, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WordDto>>> GetWords()
        {
            var words = await _wordRepository.GetWordsAsync();
            return Ok(words);
        }

        [HttpGet("english/{englishWord}")]
        public async Task<ActionResult<WordDto>> GetWordByEnglish(string englishWord)
        {
            var word = await _wordRepository.GetWordByEnglishWordAsync(englishWord);
            return Ok(word);
        }

        [HttpGet("hungary/{hungaryWord}")]
        public async Task<ActionResult<WordDto>> GetWordByHungary(string hungaryWord)
        {
            var word = await _wordRepository.GetWordByHungaryWordAsync(hungaryWord);
            return Ok(word);
        }

        [HttpPut]
        public async Task<ActionResult> ActionResult(WordDto updateWordDto)
        {
            var word = await _wordRepository.GetWordByIdAsync(updateWordDto.id);
            _mapper.Map(updateWordDto, word);

            _wordRepository.Update(word);

            if (await _wordRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update word");


        }

        [HttpPost]
        public async Task<ActionResult<WordDto>> AddWord(AddWordDto addWordDto)
        {
            //WIP ELLENŐRZÉS
            var word  = _mapper.Map<Word>(addWordDto);
            await _wordRepository.AddWord(word);
            return _mapper.Map<WordDto>(word);

            
        }

    }
}
