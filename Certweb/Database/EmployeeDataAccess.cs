using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;

namespace Certweb.Database
{
    public class EmployeeDataAccess
    {
        public static DataTable FindAllEmployees()
        {
            SqlCeConnection con = new SqlCeConnection(@"Data Source=C:\Users\Usuario\Desktop\Projetos\Certweb\Certweb\Certweb\Database\Database.sdf");
            SqlCeDataAdapter da = new SqlCeDataAdapter("SELECT * FROM Employee", con);
            DataSet ds = new DataSet();

            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}
