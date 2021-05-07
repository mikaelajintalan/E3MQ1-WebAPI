using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoDbContext _context;
        public ToDoService(ToDoDbContext context)
        {
            _context = context;
        }
        public async Task<ToDo> Create(ToDo toDo)
        {
            _context.ToDos.Add(toDo);
            await _context.SaveChangesAsync();

            return toDo;
        }
        public async Task Delete(int Id)
        {
            var itemToDelete = await _context.ToDos.FindAsync(Id);
            _context.ToDos.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDo>> Get()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<ToDo> Get(int id)
        {
            return await _context.ToDos.FindAsync(id);
        }

        public async Task Update(ToDo toDo)
        {
            _context.Entry(toDo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
