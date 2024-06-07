using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Notification:Entity<int>
{
    public string Title { get; set; }
    public string Text { get; set; }
    public int LecturerId { get; set; }
 

    public virtual Lecturer Lecturer { get; set; }

}
