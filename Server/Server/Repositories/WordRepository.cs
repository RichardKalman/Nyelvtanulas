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
    public class WordRepository : RepositoryBase<Word>,IWordRepository
    {
        private readonly IMapper _mapper;

        public ILessonWordRepository _lessonWordRepository { get; }

        public WordRepository(DataContext context, IMapper mapper, ILessonWordRepository lessonWordRepository) : base(context)
        {
            _mapper = mapper;
            _lessonWordRepository = lessonWordRepository;
        }

        public async Task<WordDto> GetWordByEnglishWordAsync(string englishWord)
        {
            return await _context.Words
                .Where(x => x.EnglishWord.ToLower() == englishWord.ToLower())
                .ProjectTo<WordDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(); ;
        }

        public async Task<WordDto> GetWordByHungaryWordAsync(string hungaryWord)
        {
            return await _context.Words
                .Where(x => x.HungaryWord.ToLower() == hungaryWord.ToLower())
                .ProjectTo<WordDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(); ;
        }

        public async Task<Word> GetWordByIdAsync(int id)
        {
            return await _context.Words
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<WordDto>> GetWordsAsync()
        {
            return await _context.Words.ProjectTo<WordDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<WordDto>> GetWordsByIds(IEnumerable<int> ids)
        {
            return await _context.Words.Where(x => ids.Contains(x.Id)).ProjectTo<WordDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
      

        public async Task<bool> addAllWords(IEnumerable<Word> words)
        {
            foreach (var word in words)
            {
                _context.Words.Add(word);
            }
            return await SaveAllAsync();
        }

        public async Task<Word> AddWord(AddWordDto addWordDto)
        {
            var word = _mapper.Map<Word>(addWordDto);
            _context.Words.Add(word);
            if(await this.SaveAllAsync())
            {
                return word;
            }
            return null;
        }

        public async Task<bool> IsExist(Word word)
        {
            return await _context.Words.AnyAsync(x => x.Id.Equals(word.Id));
                
        }

        public async Task<bool> DeleteWordById(int id)
        {
            if(!(await _lessonWordRepository.DeleteAllByWordId(id)))
            {
                return false;
            }
            var word = await _context.Words.Where(w => w.Id == id).SingleOrDefaultAsync();
            _context.Remove(word);
            return await SaveAllAsync();
         }
    }
}
