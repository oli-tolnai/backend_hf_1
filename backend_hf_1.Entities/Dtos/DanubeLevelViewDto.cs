using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_hf_1.Entities.Dtos
{
    public class DanubeLevelViewDto
    {
        public DanubeLevelViewDto(string date, double average_value, int minimal_value, int maximal_value)
        {
            Date = date;
            Average_value = average_value;
            Minimal_value = minimal_value;
            Maximal_value = maximal_value;
        }

        public string Date { get; set; } 

        [DisplayName("avarage:value")]
        public double Average_value { get; set; }

        [DisplayName("minimal_value")]
        public int Minimal_value { get; set; }

        [DisplayName("Maximal_value")]
        public int Maximal_value { get; set; }

    }
}
