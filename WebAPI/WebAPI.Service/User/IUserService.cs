using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIPractise.Model;
using WebAPIPractise.Service.User.Dto;

namespace WebAPIPractise.Service.User
{
    public interface IUserService
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
         Task<Users> CheckLogin(LoginDto login);
        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        UserDto AddUser(InputUserDto input);
        /// <summary>
        /// 獲取VIP課程
        /// </summary>
        /// <returns></returns>
        List<Courses> GetCourses();
    }
}
