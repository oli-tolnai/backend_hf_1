using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_hf_1.Entities.Dtos
{
    public class DanubeLevelCreateDto
    {
        [DataType(DataType.Date)]
        public required DateTime Date { get; set; }

        public required int Value { get; set; }


    }
}
