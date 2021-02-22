using DesafioGitHubApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGitHubApiTestes.Services
{
    public class FavoritoServicesConf
    {
        protected FavoritoServicesConf(DbContextOptions<RepositorioContexto> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        protected DbContextOptions<RepositorioContexto> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new RepositorioContexto(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();               
            }
        }
    }
}
