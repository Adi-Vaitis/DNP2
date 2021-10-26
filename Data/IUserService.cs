using DNP2.Models;

namespace DNP2.Data
{
    public interface IUserService
    {
        User ValidateUser(string UserName, string Password);
    }
}