using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IGI_5.Models
{
    public class Schedule
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
