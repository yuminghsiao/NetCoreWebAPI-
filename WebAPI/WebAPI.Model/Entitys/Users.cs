using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace WebAPIPractise.Model
{
    public class Users
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int Id { get; set; }
        public string QQ { get; set; }
        public string Mobile { get; set; }
        public string PassWord { get; set; }
        public string NickName { get; set; }

        public DateTime RegDate { get; set; }
        public int LoginNum { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public byte UserType { get; set; }
        public string UserSex { get; set; }
        public byte Status { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public int? LastModifierId { get; set; }

    }
}
