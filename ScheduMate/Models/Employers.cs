using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduMate.Models
{
    public class Employers
    {
        public int  id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public byte Rate { get; set; }

        public byte[] Photo { get; set; }

    }
}