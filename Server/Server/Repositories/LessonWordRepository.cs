using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Entities;
using Server.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public class LessonWordRepository : RepositoryBase<LessonRepository>,ILessonWordRepository
    {
        private readonly IMapper _mapper;
        public LessonWordRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public Task<bool> AddAllLessonByWordId(int wordId, IEnumerable<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> AddAllWordByLessonId(int lessonId, IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                await _context.LessonWords.AddAsync(new LessonWord { LessonId = lessonId, WordId = id });
            }
            return await SaveAllAsync();
        }

        public async Task<bool> DeleteAllByLessonId(int id)
        {
            var delete = await _context.LessonWords.Where(x => x.LessonId == id).ToListAsync();

            
            _context.RemoveRange(delete);
            return await SaveAllAsync();
        }
    }
}
