using webapi.Models;

namespace webapi.Services
{
    public interface iRoleRepo
    {
        int GetRole(User user);
        int GetRole(string username);
    }
}