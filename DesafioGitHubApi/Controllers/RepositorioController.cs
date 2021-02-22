using DesafioGitHubApi.Interfaces;
using DesafioGitHubApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioGitHubApi.Controllers
{
    //api/repositorio[controller]
    [Route("api/[controller]")]
    [ApiController]    
    public class RepositorioController : ControllerBase
    {
        // private readonly ILogger<RepositorioController> _logger;
        private readonly IRepositorioGitHubService _repositorioGitHubService;
        private readonly IFavoritoService _favoritoService;
        private readonly String url = "https://api.github.com/users/matheusff/repos";

        public RepositorioController(IRepositorioGitHubService repositorioGitHubService,
            IFavoritoService favoritoService)
        {
            _repositorioGitHubService = repositorioGitHubService;
            _favoritoService = favoritoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RepositorioGitHub>>> GetAll()
        {
            try
            {
                //_repositorioGitHubService = new RepositorioGitHubService();
                var result = await _repositorioGitHubService.GetRepositorioGitHubList(url);
                var favoritosList = await _favoritoService.GetAll();

                //Pesquisa no repositório dos favoritos
                favoritosList.ForEach(f =>
                    result.FirstOrDefault(r => r.full_name == f.full_name ?
                        r.favorito = true : r.favorito = false)
                );

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
    }

}
