using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Tepe.Entities.Concrete;

namespace Tepe.Dal.Concrete.EntityFramework
{
    public class TepeContext:IdentityDbContext<Student>
    {
        public TepeContext()
        {

        }

        public TepeContext(DbContextOptions<TepeContext> options) : base(options)
        {
        }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TepeDB;Trusted_Connection=true");
        }
       


        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }


    }
}
