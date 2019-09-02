using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IGI_5.Models
{
    public class Subject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Teacher { get; set; }
        public List<Schedule> Schedules { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
