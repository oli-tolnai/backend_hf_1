using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace backend_hf_1.Entities.Entity_Models
{
    public class DanubeLevel
    {
        public DanubeLevel(DateTime date, int level)
        {
            Id = Guid.NewGuid().ToString();
            Date = date;
            Level = level;
        }

        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int Level { get; set; }
  
    }
}
