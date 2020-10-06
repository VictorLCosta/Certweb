using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using Certweb.Models;

namespace Certweb.Database
{
    public class EmployeeDataAccess
    {
        private static SqlCeConnection con = new SqlCeConnection(@"Data Source=C:\Users\Usuario\Desktop\Projetos\Certweb\Certweb\Certweb\Database\Database.sdf");

        public static DataTable FindAllEmployees()
        { 
            SqlCeDataAdapter da = new SqlCeDataAdapter("SELECT * FROM Employee", con);
            DataSet ds = new DataSet();

            da.Fill(ds);
            return ds.Tables[0];
        }

        public static async Task<bool> CreateEmployee(Employee employee)
        {
            string sql = "INSERT INTO Employee " +
                "(Name, Email, Salary, Gender, ContractType, RegisterDate) " +
                "VALUES (@Name, @Email, @Salary, @Gender, @ContractType, @RegisterDate";

            SqlCeCommand command = new SqlCeCommand(sql, con);

            command.Parameters.Add("@Name", employee.Name);
            command.Parameters.Add("@Email", employee.Email);
            command.Parameters.Add("@Salary", employee.Salary);
            command.Parameters.Add("@Gender", employee.Gender);
            command.Parameters.Add("@ContractType", employee.ContractType);
            command.Parameters.Add("@RegisterDate", employee.RegisterDate);

            await con.OpenAsync();
            if (await command.ExecuteNonQueryAsync() > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }

        } 
    }
}
