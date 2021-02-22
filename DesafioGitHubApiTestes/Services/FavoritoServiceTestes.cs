using DesafioGitHubApi.Interfaces;
using DesafioGitHubApi.Models;
using DesafioGitHubApi.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace DesafioGitHubApiTestes.Services
{
    public class FavoritoServiceTestes : RespoitorioFavoritoConfBanco
    {
        private readonly FavoritoService _favoritoService;

        public FavoritoServiceTestes()
        {
            _favoritoService = new FavoritoService(new RepositorioContexto(ContextOptions));
        }

        [Fact]
        public void TesteBuscarPorId()
        {
            List<RepositorioFavorito> repositorioFavoritos = new List<RepositorioFavorito>();
            var repositorioFavorito = CriarRepositorioFavorito();
            repositorioFavoritos.Add(repositorioFavorito);
            if (_favoritoService.Add(repositorioFavoritos).Result)
            {
                var resultTest = _favoritoService.GetById(1);

                Assert.NotNull(resultTest);
            }

        }

        private RepositorioFavorito CriarRepositorioFavorito()
        {
            RepositorioFavorito repositorioFavorito = new RepositorioFavorito();
            repositorioFavorito.description = "Teste";
            repositorioFavorito.favorito = false;
            repositorioFavorito.full_name = "Projeto Teste";
            repositorioFavorito.html_url = "Teste Url";
            repositorioFavorito.Id = 1;
            repositorioFavorito.language = "Linguagem teste";
            repositorioFavorito.name = "Projeto Teste";
            repositorioFavorito.updated_at = new DateTime();

            return repositorioFavorito;
        }
    }
}
