using System.Threading.Tasks;
using DNP2.Models;

namespace DNP2.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string UserName, string Password);
    }
}