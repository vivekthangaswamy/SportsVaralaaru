using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportsVaralaaruAPI.Models
{
    public class SportsVaralaaruAPIContext : DbContext
    {
        public SportsVaralaaruAPIContext (DbContextOptions<SportsVaralaaruAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SportsVaralaaruAPI.Models.Sports> Sports { get; set; }
    }
}
