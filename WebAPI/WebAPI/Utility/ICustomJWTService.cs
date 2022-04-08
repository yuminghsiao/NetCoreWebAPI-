using WebAPIPractise.Model;

namespace WebAPI.Utility
{
    public interface ICustomJWTService
    {
        //獲取token
        string GetToken(Users user);
    }
}
