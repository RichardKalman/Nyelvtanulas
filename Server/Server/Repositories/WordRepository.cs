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
    public class WordRepository : IWordRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public WordRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<WordDto> GetWordByEnglishWordAsync(string englishWord)
        {
            return await _context.Words
                .Where(x => x.EnglishWord == englishWord)
                .ProjectTo<WordDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(); ;
        }

        public async Task<WordDto> GetWordByHungaryWordAsync(string hungaryWord)
        {
            return await _context.Words
                .Where(x => x.HungaryWord == hungaryWord)
                .ProjectTo<WordDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(); ;
        }

        public async Task<Word> GetWordByIdAsync(int id)
        {
            
            //SaveAllAsync();
            return await _context.Words
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<WordDto>> GetWordsAsync()
        {
            return await _context.Words.ProjectTo<WordDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Word word)
        {
            _context.Entry(word).State = EntityState.Modified;
        }

        public async Task<bool> AddWord(Word word)
        {
            _context.Words.Add(word);
            return await this.SaveAllAsync();
        }

         
    }
}
