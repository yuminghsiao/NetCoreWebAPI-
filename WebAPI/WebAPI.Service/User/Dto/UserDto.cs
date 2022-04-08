using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIPractise.Service.User.Dto
{
    public class UserDto
    {
        public string QQ { get; set; }
        public string Mobile { get; set; }
        public string NickName { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public byte UserType { get; set; }
        public string UserSex { get; set; }
        public byte Status { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
