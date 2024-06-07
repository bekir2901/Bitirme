using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Student:Entity<int>
{
    public int No { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int FormalType { get; set; }
    public int EntryYear { get; set; }

    public virtual ICollection<Message> Messages { get; set; }// bir öğrenci birden fazla meaj yazabilir

    //public virtual FirstInternship FirstInternship { get; set; } // her staj bir studenta aittir

    //public virtual SecondInternship SecondInternship { get; set; } // her staj bir studenta aittir


}
