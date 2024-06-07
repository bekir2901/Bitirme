using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Message:Entity<int>
{
    public int StudentId { get; set; }
    public int LecturerId { get; set; }
    public string Text { get; set; }
    public string Title { get; set; }

    public virtual Student Student { get; set; } // her mesaj bir studenta aittir

    public virtual Lecturer Lecturer { get; set; } // her mesaj bir studenta aittir


}
