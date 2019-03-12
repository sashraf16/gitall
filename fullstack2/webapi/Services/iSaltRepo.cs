using webapi.Models;

namespace webapi.Services
{
    public interface iSaltRepo
    {
        Salts GetSalt(int UserId);
    }
}