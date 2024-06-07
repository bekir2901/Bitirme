using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class FirstInternship : Entity<int>
{
    public int StudentId { get; set; }
    public int LecturerId { get; set; }
    public string Message { get; set; }
    public bool Progress { get; set; }

    public virtual Student Student { get; set; } // her staj bir studenta aittir

    public virtual Lecturer Lecturer { get; set; } // her staj bir Lecture aittir


}
