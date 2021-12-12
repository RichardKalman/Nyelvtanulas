using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs;
using Server.Entities;
using Server.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public class LessonResultRepository : RepositoryBase<LessonResult>, ILessonResultRepository
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly IWordRepository _wordRepository;
        private readonly IUserRepository _userRepository;

        public LessonResultRepository(IMapper mapper ,DataContext context, ILessonRepository lessonRepository, IWordRepository wordRepository , IUserRepository userRepository) : base(context)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
            _wordRepository = wordRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<LessonResultDto>> GetAll()
        {
            return await _context.LessonResult.ProjectTo<LessonResultDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<LessonResultDto>> GetByUserId(int userId)
        {
            return await _context.LessonResult.
                Where( t=> t.Users.Any(u => u.AppUserId == userId)).
                ProjectTo<LessonResultDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<LessonResultDto> GetById(int id)
        {
            return await _context.LessonResult.Where(t => t.Id == id).ProjectTo<LessonResultDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<LessonResultDto> AddResultAsync(LessonResultRequestDto dto)
        {
            var badword = await checkBadWordAsync(dto.words);
            var correctword = await checkCorrectWordAsync(dto.words);
            var user = await _userRepository.GetUserByIdAsync(dto.userId);
            var lesson = await _lessonRepository.GetLessonByIdWithLessonTypeAsync(dto.lessonId);
            

            var LessonResult = new LessonResult
            {
                CorrectWord = correctword,
                NotCorrectWord = badword,
            };

            await _context.LessonResult.AddAsync(LessonResult);
            if(!await SaveAllAsync())
            {
                return null;
            }

            await _context.UserLessonResults.AddAsync(new UserLessonResult { AppUser = user , AppUserId = dto.userId, LessonResult = LessonResult , LessonResultId = LessonResult.Id });
            await _context.LessonLessonResults.AddAsync(new LessonLessonResult { LessonResult = LessonResult, LessonResultId = LessonResult.Id, LessonId = dto.lessonId, Lesson = lesson});

            if(!await SaveAllAsync())
            {
                return null;
            }


            return _mapper.Map<LessonResultDto>(LessonResult);
        }

        private async Task<int> checkBadWordAsync(IEnumerable<WordDto> words)
        {
            int db = 0;
            foreach(var word in words)
            {
                var wordFromDb = await _wordRepository.GetWordByIdAsync(word.id);
                if(wordFromDb == null)
                {
                    db++;
                    continue;
                }
                if(wordFromDb.HungaryWord.ToLower() != word.HungaryWord.ToLower())
                {
                    db++;
                }
            }
            return db;
        }
        private async Task<int> checkCorrectWordAsync(IEnumerable<WordDto> words)
        {
            int db = 0;
            foreach (var word in words)
            {
                var wordFromDb = await _wordRepository.GetWordByIdAsync(word.id);
                if (wordFromDb == null)
                {
                    continue;
                }
                if (wordFromDb.HungaryWord.ToLower() == word.HungaryWord.ToLower())
                {
                    db++;
                }
            }
            return db;
        }
    }
}
