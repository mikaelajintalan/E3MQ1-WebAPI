using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class ToDo
    {
        [Key]
        public int ToDoId { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string ToDoName { get; set; }
        public bool Completed { get; set; }
    }
}
