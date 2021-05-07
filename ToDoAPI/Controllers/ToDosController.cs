using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        public ToDosController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDo>> GetTodos()
        {
            return await _toDoService.Get();
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> PostTodos([FromBody] ToDo toDo)
        {
            var newToDo = await _toDoService.Create(toDo);
            return CreatedAtAction(nameof(GetTodos), new { Id = newToDo.Id }, newToDo);
        }

        [HttpPut]
        public async Task<ActionResult> PutTodos([FromBody] ToDo toDo)
        {
            await _toDoService.Update(toDo);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] ToDo toDo)
        {
            var itemToDelete = await _toDoService.Get(toDo.Id);
            if (itemToDelete == null) return NotFound();

            await _toDoService.Delete(itemToDelete.Id);
            return NoContent();
        }

    }
}
