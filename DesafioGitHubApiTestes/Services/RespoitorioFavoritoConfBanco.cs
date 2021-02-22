using DesafioGitHubApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioGitHubApiTestes.Services
{
    public class RespoitorioFavoritoConfBanco : FavoritoServicesConf
    {
        public RespoitorioFavoritoConfBanco()
        : base(
            new DbContextOptionsBuilder<RepositorioContexto>()
                .UseSqlite("Filename=Test.db")
                .Options)
        {
        }
    }
}
