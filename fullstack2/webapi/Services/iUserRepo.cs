using System;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Services
{
    public interface IUserRepo
    {
        String CreateSalt(int size);
        String GenerateSHA256Hash(string input, string salt);
        string ByteArrayToHexString(byte[] ba);
        string HashPassword(string password);


        bool verifyUser(User user, string password);
        string getPass(string Username);


        List<User> getUsers();
        User GetUser(string username);
        int insertUser(User user);

    }
}