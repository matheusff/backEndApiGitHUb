using DesafioGitHubApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioGitHubApi.Interfaces
{
    public interface IFavoritoService
    {
        Task<List<RepositorioFavorito>> GetAll();

        Task<RepositorioFavorito> GetById(Int64 Id);

        Task<Boolean> Add(List<RepositorioFavorito> repositorioFavoritoList);

        void RemoveAll();
    }
}
