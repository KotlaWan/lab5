using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IGI_5.Models
{
    public class Class
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ClassLead { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int ClassTypeId { get; set; }
        public ClassType ClassType { get; set; }
        public List<Student> Students { get; set; }
        public List<Schedule> Schedules { get; set; }
        public override string ToString()
        {
            return ClassLead;
        }
    }
}
