using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace WebAPIPractise.Common.Db
{
    /// <summary>
    /// 資料庫連接
    /// </summary>
    public class DbContext
    {
        public static SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = "Data Source=localhost;Initial Catalog=WebAPI;User ID=test;password=test",
            DbType = DbType.SqlServer,
            IsAutoCloseConnection = true//不設成true要手動close
        });
    }
}
