using Server.DTOs;
using Server.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public interface IWordRepository
    {
        void Update(Word word);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<WordDto>> GetWordsAsync();
        Task<bool> AddWord(AddWordDto word);

        Task<bool> IsExist(Word word);
        Task<List<WordDto>> GetWordsByIds(IEnumerable<int> ids);
        Task<Word> GetWordByIdAsync(int id);
        Task<WordDto> GetWordByHungaryWordAsync(string hungaryWord);
        Task<WordDto> GetWordByEnglishWordAsync(string englishWord);
    }
}
