using System;
using System.Collections.Generic;
using asp.net.Models;

namespace asp.net.Services
{
    public interface ITaskRepository
    {
         List<Todo> GetTasks();
         Todo GetTask(int id);
         Boolean InsertTask(Todo newTask);
    }
}