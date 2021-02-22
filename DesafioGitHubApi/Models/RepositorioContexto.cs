using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioGitHubApi.Models
{
    public class RepositorioContexto : DbContext
    {
        public RepositorioContexto(DbContextOptions<RepositorioContexto> options) : base(options)
        {
        }
        public DbSet<RepositorioFavorito> RepositorioFavoritos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RepositorioFavorito>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
