using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Models;

namespace Data
{
    public class PracticeDbContext : DbContext
    {
        public PracticeDbContext():base("name=PracticeBaseEntities")
        {
            Database.SetInitializer<PracticeDbContext>(null);
        }
        public DbSet<Arduino> Arduino { get; set; }
        public DbSet<CollectedData> CollectedData { get; set; }
        public DbSet<Laborant> Laborants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arduino>().ToTable("Arduino");
            modelBuilder.Entity<CollectedData>().ToTable("CollectedData");
            modelBuilder.Entity<Laborant>().ToTable("Laborants");
        }
    }
}
