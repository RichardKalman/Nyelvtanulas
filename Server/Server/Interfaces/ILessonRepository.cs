using Server.DTOs;
using Server.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public interface ILessonRepository
    {
        Task<LessonDto> AddLesson(AddLessonDto addLessonDto);

        void Update(Lesson lesson);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<LessonDto>> GetLessonsAsync();
        Task<Lesson> GetLessonByIdAsLessonAsync(int id);
        Task<LessonDto> GetLessonByIdAsync(int id);

        Task<Lesson> GetLessonByIdWithLessonTypeAsync(int id);
        Task<IEnumerable<LessonDto>> GetLessonByNameAsync(string name);
        Task<bool> DeleteLessonById(int Id);
        Task<IEnumerable<UserForAddToLesson>> GetNoAcceptUsers(int id);

        Task<bool> addUserByLessonId(int userId, int lessonId);
        Task<IEnumerable<LessonDto>> getLessonByUserId(int userId);
        //Task<LessonDto> GetWordByEnglishWordAsync(string englishWord);
    }
}
