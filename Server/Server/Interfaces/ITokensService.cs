using Server.Entities;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
