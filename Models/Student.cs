using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IGI_5.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Gender { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public override string ToString()
        {
            return FIO;
        }
    }
}
