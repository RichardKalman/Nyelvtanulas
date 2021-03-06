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
    public class LessonRepository : RepositoryBase<Lesson>,ILessonRepository
    {

        private readonly IMapper _mapper;
        private readonly ILessonWordRepository _lessonWordRepository;

        public LessonRepository(DataContext context, IMapper mapper , ILessonWordRepository lessonWordRepository) : base(context)
        {
            _mapper = mapper;
            _lessonWordRepository = lessonWordRepository;
        }
        public async Task<LessonDto> AddLesson(AddLessonDto addLessonDto)
        {
            var Ids = addLessonDto.WordIds.ToList();

            //Kimentem a szavakat
          
            var lesson = _mapper.Map<Lesson>(addLessonDto);
            
            await _context.Lessons.AddAsync(lesson);
            await SaveAllAsync();

            await _lessonWordRepository.AddAllWordByLessonId(lesson.Id,Ids);

            var lessonDto = await GetLessonByIdAsync(lesson.Id);

            return lessonDto;
        }

        public async Task<Lesson> GetLessonByIdAsLessonAsync(int id)
        {
            return await _context.Lessons.
                Where(x => x.Id == id).
                SingleOrDefaultAsync();
        }

        public async Task<LessonDto> GetLessonByIdAsync(int id)
        {
            return await _context.Lessons.
                Where(x => x.Id == id).
                ProjectTo<LessonDto>(_mapper.ConfigurationProvider).
                SingleOrDefaultAsync();
        }
        public async Task<Lesson> GetLessonByIdWithLessonTypeAsync(int id)
        {
            return await _context.Lessons.
                Where(x => x.Id == id).
                SingleOrDefaultAsync();
        }

        public async Task<bool> DeleteLessonById(int Id)
        {
            var delete = await _context.Lessons.Where(x => x.Id == Id).SingleOrDefaultAsync();
            if (delete == null)
            {
                return false;
            }
            if (await _lessonWordRepository.DeleteAllByLessonId(Id))
            {
                return false;
            }
            _context.Lessons.Remove(delete);
            return await SaveAllAsync();

        }

        public async Task<IEnumerable<LessonDto>> GetLessonByNameAsync(string name)
        {
            return await _context.Lessons.
                Where(x => x.Name == name).
                ProjectTo<LessonDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<LessonDto>> GetLessonsAsync()
        {
            return await _context.Lessons.ProjectTo<LessonDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<UserForAddToLesson>> GetNoAcceptUsers(int id)
        {
            var lesson = await _context.Lessons.Where(l => l.Id == id).ProjectTo<LessonDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            var users = lesson.Users.Select(x => x.Id);

            var noAcceptUser = await _context.Users.Where(x => !users.Contains(x.Id)).ProjectTo<UserForAddToLesson>(_mapper.ConfigurationProvider).ToListAsync();

            return noAcceptUser;
        }

        public async Task<bool> addUserByLessonId(int userId, int lessonId)
        {
            await _context.UserLesson.AddAsync(new UserLesson { AppUserId = userId, LessonId = lessonId });
            return await SaveAllAsync();
        }

        public async Task<IEnumerable<LessonDto>> getLessonByUserId(int userId)
        {
            
            return await _context.Lessons.Where(t => t.Users.Any(t => t.AppUserId == userId)).ProjectTo<LessonDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
