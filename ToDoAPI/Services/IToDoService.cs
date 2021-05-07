using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDo>> Get();
        Task<ToDo> Get(int id);
        Task<ToDo> Create(ToDo toDo);
        Task Update(ToDo toDo);
        Task Delete(int Id);
    }
}
