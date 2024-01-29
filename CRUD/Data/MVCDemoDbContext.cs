using CRUD.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions<MVCDemoDbContext> options) : base(options)
        {

        }
        public DbSet<Dosen> Dosen { get; set; }
        public DbSet<Mahasiswa> Mahasiswa { get; set; }
        public DbSet<MataKuliah> MataKuliah { get; set; }
        public DbSet<Perkuliahan> Perkuliahan { get; set; }
    }
}
