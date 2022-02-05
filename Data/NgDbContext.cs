using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _1262228_Arosh_NGJs.Models;
namespace _1262228_Arosh_NGJs.Data
{
    public class NgDbContext:DbContext
    {
        public NgDbContext(DbContextOptions<NgDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<AcademicResult> AcademicResults { get; set; }

    }
}
