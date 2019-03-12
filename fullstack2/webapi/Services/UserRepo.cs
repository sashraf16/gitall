using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.IdentityModel.Protocols;
using webapi.Models;

namespace webapi.Services {
    public class UserRepo : IUserRepo {
        private const string _connstring = @"Server=localhost\SQLEXPRESS;Database=practice database;Trusted_Connection=True";
        public User us = new User ();

        private SaltRepo _sRepo = new SaltRepo();

        public String CreateSalt (int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public String GenerateSHA256Hash(string input, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);

            return ByteArrayToHexString(hash);
        }
        public string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length*2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            
            return hex.ToString();
        }

        public string HashPassword(string password)
        {
            string salt = CreateSalt(10);
            string hashedpassword = GenerateSHA256Hash(password, salt);

            System.Console.WriteLine("salt: " + salt);

            System.Console.WriteLine(hashedpassword);
            return hashedpassword;
        }


        public User verifyUser(string password)
        {
            var saltobj = _sRepo.GetSalt(1);
            string salt = saltobj.UserSalt;
            System.Console.WriteLine("salt: " + salt);

            var testhash = GenerateSHA256Hash(salt, password);
            System.Console.WriteLine("testhash: " + testhash);

            var dbpass = getPass("bashraf");
            System.Console.WriteLine("dbpass: " + dbpass);

            if (testhash == dbpass) {
                return GetUser("bashraf");
            } else {
                return us;
            } 
        }

        public User GetUser (string name) {
            using (IDbConnection conn = new SqlConnection (_connstring)) {
                conn.Open ();
                List<User> allusers = new List<User> ();
                allusers = conn.Query<User> ("dbo.prtasks_qrygetuserbyusername", new { name }, commandType : CommandType.StoredProcedure).ToList ();
                return allusers[0];
            }
        }

        public string getPass (string Username)
        {
            using (IDbConnection conn = new SqlConnection (_connstring)) {
                conn.Open ();

                var password = conn.Query<dynamic> ("dbo.prtasks_qrypassbyusername", new { Username }, commandType : CommandType.StoredProcedure).FirstOrDefault();
                return password.Password;
            }

        }

        public List<User> getUsers () {
            using (IDbConnection conn = new SqlConnection (_connstring)) {
                conn.Open ();
                // return conn.Query<User>("select * from dbo.usertable").ToList();
                return conn.Query<User> ("dbo.prtasks_qryallusers", commandType : CommandType.StoredProcedure).ToList ();
                // System.Console.WriteLine("result: " + users);
                // return allusers;
            }

        }

        public int insertUser (User user) {
            string firstname = user.FirstName;
            string lastname = user.LastName;
            string username = user.Username;
            string password = user.Password;
            try {
                using (IDbConnection conn = new SqlConnection (_connstring)) {
                    conn.Open ();
                    var result = conn.Execute ("dbo.prtasks_insuser", new { firstname, lastname, username, password }, commandType : CommandType.StoredProcedure);
                    System.Console.WriteLine ("rows affected: " + result);
                    return result;
                }
            }
            catch (Exception e)
            {   
                System.Console.WriteLine("error: " + e);
                return 0;
            }
        }
    }
}