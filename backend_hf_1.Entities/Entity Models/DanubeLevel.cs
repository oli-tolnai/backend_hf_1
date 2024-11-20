using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend_hf_1.Entities.Entity_Models
{
    public class DanubeLevel
    {
        public DanubeLevel(DateTime date, int value)
        {
            Id = Guid.NewGuid().ToString();
            Date = date;
            Value = value;
        }

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }


        [JsonPropertyName("date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
  
    }


}
