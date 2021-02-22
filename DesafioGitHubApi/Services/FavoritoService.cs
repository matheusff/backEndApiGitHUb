using DesafioGitHubApi.Interfaces;
using DesafioGitHubApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioGitHubApi.Services
{
    public class FavoritoService : IFavoritoService
    {

        private readonly RepositorioContexto _repositorioContexto;

        public FavoritoService(RepositorioContexto repositorioContexto)
        {
            _repositorioContexto = repositorioContexto;
        }
        public Task<List<RepositorioFavorito>> GetAll()
        {
            return Task.FromResult(_repositorioContexto.RepositorioFavoritos.ToList());
        }

        public Task<RepositorioFavorito> GetById(Int64 Id)
        {
            return Task.FromResult(_repositorioContexto.RepositorioFavoritos
                .FirstOrDefault(rf => rf.Id == Id));
        }

        public async Task<Boolean> Add(List<RepositorioFavorito> repositorioFavoritoList)
        {
            RemoveAll();
            repositorioFavoritoList.ForEach(r =>
                {
                    r.favorito = true;
                    _repositorioContexto.Add(r);
                }                
            );

            int result = await _repositorioContexto.SaveChangesAsync();

            if (result > 0)
                return true;
            else
                return false;

        }

        public async void RemoveAll()
        {
            _repositorioContexto.RemoveRange(_repositorioContexto.RepositorioFavoritos);
            await _repositorioContexto.SaveChangesAsync();
        }
    }
}
