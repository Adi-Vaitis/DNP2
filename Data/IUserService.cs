namespace DNP2.Data
{
    public interface IUserService
    {
        User ValidateUser(string UserName, string Password);
    }
}