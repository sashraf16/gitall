using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using webapi.Models;

namespace webapi.Services
{
    public class SaltRepo : iSaltRepo
    {
        private const string _connstring = @"Server=localhost\SQLEXPRESS;Database=practice database;Trusted_Connection=True";

        public Salts GetSalt(int UserId)
        {
            using (IDbConnection conn = new SqlConnection (_connstring)) {
                conn.Open ();
                var result = conn.Query<Salts> ("dbo.prtasks_qrysaltbyuserid", new { UserId }, commandType : CommandType.StoredProcedure).ToList();
                Console.WriteLine(result[0].ToString());
                return result[0];
            }
        }
    }
}