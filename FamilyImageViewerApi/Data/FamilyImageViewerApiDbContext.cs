using FamilyImageViewerApi.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyImageViewerApi.Data
{
    public class FamilyImageViewerApiDbContext:DbContext
    {
        public FamilyImageViewerApiDbContext(DbContextOptions<FamilyImageViewerApiDbContext> options):base(options)
        {

        }

       public DbSet<Family> Families { get; set; }

    }
}
