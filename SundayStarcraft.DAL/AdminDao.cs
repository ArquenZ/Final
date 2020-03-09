using SundayStarcraft.DAL.Interfaces;
using SundayStarcraft.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundayStarcraft.DAL
{
    public class AdminDao: IAdminDao
    {
       private string _connectionString = ConString.Value;       
        public int Add(Admin admin) 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertAdmin";
                SqlParameter outputParameter = new SqlParameter(){ ParameterName = "@ID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                SqlParameter[] parameters =
                    {
                    new SqlParameter() {ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = admin.Name},
                    new SqlParameter() {ParameterName = "@Login", SqlDbType = SqlDbType.NVarChar, Value = admin.Login},
                    new SqlParameter() {ParameterName = "@Password", SqlDbType = SqlDbType.NVarChar, Value = admin.Password}                    
                    };
                command.Parameters.AddRange(parameters);
                command.Parameters.Add(outputParameter);
                connection.Open();
                command.ExecuteNonQuery();
                admin.AdminID = (int)outputParameter.Value;
                return admin.AdminID;
            }
        }
        public Admin GetByID(int id) 
        {
            Admin admin = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAdminById";

                var idParameter = new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@ID", Value = id };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    admin = new Admin()
                    {
                        AdminID = id,
                        Password = reader["Password"] as string,
                        Name = reader["Name"] as string,
                        Login = reader["Login"] as string
                    };
                }
            }
            return admin;
        }
        public IEnumerable<Admin> GetAll ()
        {
            List<Admin> admins = new List<Admin>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.SelectAllAdmin";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    admins.Add(new Admin
                    {
                        AdminID = (int)reader["ID"],
                        Password = reader["Password"] as string,
                        Name = reader["Name"] as string,
                        Login = reader["Login"] as string
                    });
                }
            }
            return admins;
        }
        public void DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAdminById";
                SqlParameter Parameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                };
                command.Parameters.Add(Parameter);
                connection.Open();
                command.ExecuteNonQuery();                
            }            
        }
    }
}
