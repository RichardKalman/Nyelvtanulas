using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public interface ILessonWordRepository
    {
        Task<bool> DeleteAllByLessonId(int ids);
        Task<bool> AddAllWordByLessonId(int lessonId, IEnumerable<int> ids);
        Task<bool> AddAllLessonByWordId(int wordId, IEnumerable<int> ids);
    }
}
