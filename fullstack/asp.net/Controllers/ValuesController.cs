using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp.net.Models;

namespace asp.net.Controllers {
    [Route ("api/[controller]")]
    public class ValuesController : Controller {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=practice database;Trusted_Connection=True";

        // GET api/values
        [HttpGet]
        public List<string> GetTasks () 
        { 
            SqlConnection conn2 = new SqlConnection(ConnectionString);

            try 
            {
                conn2.Open();
            }

            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }

            conn2.Close();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                SqlCommand getall = new SqlCommand("Select * from tasks", conn);

                SqlDataReader reader = getall.ExecuteReader();

                // var result = getall.ExecuteNonQuery();

                // List<Todo> todolist = new List<Todo>();
                List<string> todolist = new List<string>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = (string) reader["task"];
                        // Todo task = new Todo();
                        // task.Id = (int) reader["Id"];
                        // task.Item = (string) reader["task"];

                        // todolist.Add(task);

                        // todolist.Add(task.Item);
                        // System.Console.WriteLine(reader.GetString(1));

                        todolist.Add(name);
                    }
                }

                return todolist;

                
                // SqlCommand proc = new SqlCommand("getlist", conn);

                // proc.CommandType = CommandType.StoredProcedure;
            }
            

            // var values = _context.Values.ToList();

            // return Ok(values);
        }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public IActionResult GetValue (int id) 
        // {
        //     var value = _context.Values.FirstOrDefault(x => x.Id == id);

        //     return Ok(value);
        }
    }