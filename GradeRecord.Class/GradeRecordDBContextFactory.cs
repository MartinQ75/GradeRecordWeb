using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeRecord.Class;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace GradeRecord.Class
{
    public class GradeRecordDBContextFactory : IDesignTimeDbContextFactory<GradeRecordDB>
    {
        GradeRecordDB IDesignTimeDbContextFactory<GradeRecordDB>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GradeRecordDB>();
            optionsBuilder.UseSqlServer("Server=MQUIRINO\\SQLEXPRESS;Database=GradeRecordDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new GradeRecordDB(optionsBuilder.Options);
        }
    }
}
