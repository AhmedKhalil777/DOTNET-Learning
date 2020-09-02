using System.Threading.Tasks;

namespace MyApplication.API.Services
{
    public interface IIdentityService
    {
        string CreateSecurityToken(string Username, string Email, string Role);
    }
}