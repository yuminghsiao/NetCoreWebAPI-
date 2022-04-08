using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIPractise.Service.User.Dto
{
    public class InputUserDto
    {
        public string QQ { get; set; }
        public string Mobile { get; set; }
        public string PassWord { get; set; }
        public string NickName { get; set; }
        public string UserSex { get; set; }
        public string ValidateKey { get; set; }
        public string ValidateCode { get; set; }
    }
}
