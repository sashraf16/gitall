using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using asp.net.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp.net.Controllers {
    [Route ("api/[controller]")]
    public class ValuesController : Controller {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=practice database;Trusted_Connection=True";

        // GET api/values
        [HttpGet]
        public List<Todo> GetTasks () {
            using (SqlConnection conn = new SqlConnection (ConnectionString)) {
                conn.Open ();

                SqlCommand getall = new SqlCommand ("Select * from tasks", conn);

                SqlDataReader reader = getall.ExecuteReader ();

                // var result = getall.ExecuteNonQuery();

                // List<Todo> todolist = new List<Todo>();
                List<Todo> todolist = new List<Todo> ();
                if (reader.HasRows) {
                    while (reader.Read ()) {
                        // string name = (string) reader.GetString(1);
                        int id = (Int32) reader["Id"];
                        string name = (string) reader["item"];

                        // int id = (Int16) reader["Id"];
                        Todo task = new Todo ();
                        task.Id = id;
                        task.Item = name;

                        // todolist.Add(task);

                        // todolist.Add(task.Item);
                        // System.Console.WriteLine(reader.GetString(1));

                        // System.Console.WriteLine(task.Id);
                        // System.Console.WriteLine(task.Item);

                        todolist.Add (task);
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
        [HttpGet ("{id}")]
        public Todo GetTask (int id) {
            using (SqlConnection conn = new SqlConnection (ConnectionString)) {
                conn.Open ();

                Todo task = new Todo ();
                using (SqlCommand gettask = new SqlCommand ("Select * from tasks where id = @id", conn)) {
                    gettask.Parameters.Add (new SqlParameter ("id", id));

                    SqlDataReader reader = gettask.ExecuteReader ();

                    if (reader.HasRows) {
                        while (reader.Read ()) {
                            int ids = (Int32) reader["Id"];
                            string name = (string) reader["item"];

                            task.Id = ids;
                            task.Item = name;

                            return task;
                        }
                    }
                }

                return task;
            }
        }
    }
}