using Server.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public interface ILessonResultRepository
    {
        Task<LessonResultDto> AddResultAsync(LessonResultRequestDto dto);
        Task<LessonResultDto> GetById(int id);
        Task<IEnumerable<LessonResultDto>> GetByUserId(int userId);

        Task<IEnumerable<LessonResultDto>> GetAll();

    }
}
