using System.Collections.Generic;
using asp.net.Models;
using asp.net.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace asp.net.Controllers
{
    [Route ("api/[controller]")]
    public class ValuesController : Controller 
    {
        private TaskRepository taskRepository = new TaskRepository();
        // private const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=practice database;Trusted_Connection=True";

        // GET api/values
        [HttpGet]
        public IEnumerable<Todo> GetTasks () {
            var results = taskRepository.GetTasks();
            return results;
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public Todo GetTask (int id) {
            return taskRepository.GetTask (id);
        }

        //POST api/values/insert
        [HttpPost]
        public bool InsertTask(Todo newTask) {
            return taskRepository.InsertTask(newTask);
        }
    }
}