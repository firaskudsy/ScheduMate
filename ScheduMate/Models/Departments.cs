using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduMate.Models
{
    public class Departments
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Department { get; set; }

    }
}