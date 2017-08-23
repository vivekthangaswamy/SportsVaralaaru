using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsVaralaaruAPI.Models
{
    public class Sports
    {
        public int Id { get; set; }

        [Required]
        public string SportName { get; set; }

        public string Type { get; set; }

        public string Desc { get; set; }

        public string Kind { get; set; }

    }
}
