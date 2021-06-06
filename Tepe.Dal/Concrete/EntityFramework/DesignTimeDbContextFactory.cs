using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tepe.Dal.Concrete.EntityFramework
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TepeContext>
    {
        public TepeContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TepeContext>();
            var connectionString = "Server=Server=(localdb)\\mssqllocaldb;Database=TepeDB;Trusted_Connection=true";
            builder.UseSqlServer(connectionString);
            return new TepeContext(builder.Options);
        }
    }
}
