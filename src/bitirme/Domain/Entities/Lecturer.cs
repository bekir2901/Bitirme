using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Lecturer:Entity<int>
{
    public string Name { get; set; }
    public string Email { get; set; }

    public virtual ICollection<SecondInternship> SecondInternships { get; set; }// bir Lecturer birden fazla staj danışabilir
    public virtual ICollection<FirstInternship> FirstInternships { get; set; }// bir Lecturer birden fazla staj danışabilir



}
