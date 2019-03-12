using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using webapi.Models;

namespace webapi.Services {
    public class RoleRepo : iRoleRepo {
        private const string _connstring = @"Server=localhost\SQLEXPRESS;Database=practice database;Trusted_Connection=True";

        public int GetRole (User user) {
            int userId = user.UserId;
            using (IDbConnection conn = new SqlConnection (_connstring)) {
                conn.Open ();
                var result = conn.Query<Roles> ("dbo.prtasks_qryrolebyuserid", new { userId }, commandType : CommandType.StoredProcedure).ToList();
                System.Console.WriteLine("result: " + result);
                return result[0].Role;
            }
        }

        public int GetRole(string username)
        {
            string userId = username;
            using (IDbConnection conn = new SqlConnection (_connstring)) {
                conn.Open ();
                var result = conn.Query<Roles> ("dbo.prtasks_qryrolebyuserid", new { userId }, commandType : CommandType.StoredProcedure).ToList();
                System.Console.WriteLine("result: " + result[0]);
                System.Console.WriteLine("result: " + result[0].ToString());
                return result[0].Role;
            }
        }
    }
}