using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class ToDoDbContext:DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
