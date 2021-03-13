using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuanGrullon.Models
{
    public class Tarea
    {
        [AutoIncrement][PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public bool IsComplete { get; set; } // 1 = Task Completed/ 2 = Task Incompleted
        public DateTime CreationDate { get; set; }
    }
}
