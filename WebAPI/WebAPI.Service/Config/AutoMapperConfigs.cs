using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIPractise.Model;
using WebAPIPractise.Service.User.Dto;

namespace WebAPIPractise.Service.Config
{
    /// <summary>
    /// 管理映射
    /// </summary>
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            CreateMap<Users, UserDto>();
            CreateMap<InputUserDto, Users> ();
        }
    }
}
