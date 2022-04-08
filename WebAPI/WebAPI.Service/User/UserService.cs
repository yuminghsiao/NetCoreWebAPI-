using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIPractise.Common.Db;
using WebAPIPractise.Model;
using WebAPIPractise.Service.User.Dto;

namespace WebAPIPractise.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<Users> CheckLogin(LoginDto login)
        {
            return await DbContext.db.Queryable<Users>().FirstAsync(m => m.QQ.Equals(login.QQ) && m.PassWord.Equals(login.PassWord));
        }
        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public UserDto AddUser(InputUserDto input)
        {
            Users user = TransInputDto(input);
            if (!DbContext.db.Queryable<Users>().Any(m => m.QQ.Equals(input.QQ) || m.Mobile.Equals(input.Mobile)))
            {
                DbContext.db.Insertable(user).ExecuteCommand();
                return _mapper.Map<UserDto>(user);
            }
            else
                throw new Exception("QQ 或者 手機號碼已存在");
        }

        private Users TransInputDto(InputUserDto input)
        {
            var user =_mapper.Map<Users>(input);
            var date = DateTime.Now;
            user.RegDate = date;
            user.CreateTime = date;
            user.LastModifyTime = date;
            user.LoginNum = 0;
            user.UserType = 1;
            user.Status = 1;
            user.CreatorId = 1;
            user.LastModifierId = 1;
            return user;
        }
        /// <summary>
        /// 假數據
        /// </summary>
        /// <returns></returns>
        public List<Courses> GetCourses()
        {
            List<Courses> courses = new List<Courses>();
            courses.Add(new Courses() { Id=1,Name="test",Path="https://www.google.com",VaildCode="123456",Content="test測試"});
            courses.Add(new Courses() { Id=2,Name="test",Path="https://www.google.com",VaildCode="123456",Content="test測試"});
            courses.Add(new Courses() { Id=3,Name="test",Path="https://www.google.com",VaildCode="123456",Content="test測試"});
            courses.Add(new Courses() { Id=4,Name="test",Path="https://www.google.com",VaildCode="123456",Content="test測試"});
            courses.Add(new Courses() { Id=5,Name="test",Path="https://www.google.com",VaildCode="123456",Content="test測試"});
            courses.Add(new Courses() { Id=6,Name="test",Path="https://www.google.com",VaildCode="123456",Content="test測試"});
            courses.Add(new Courses() { Id=7,Name="test",Path="https://www.google.com",VaildCode="123456",Content="test測試"});
            return courses;
        }
    }
}
