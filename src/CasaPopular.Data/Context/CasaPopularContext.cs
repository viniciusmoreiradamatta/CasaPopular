using CasaPopular.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaPopular.Data.Context
{
    public class CasaPopularContext : DbContext
    {
        public CasaPopularContext(DbContextOptions op) : base(op)
        {
        }

        public DbSet<Renda> Renda { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<Criterio> Criterio { get; set; }
        public DbSet<FamiliaSelecionada> FamiliaSelecionada { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}