using DesafioGitHubApi.Interfaces;
using DesafioGitHubApi.Models;
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
    public class FavoritoController : ControllerBase
    {
        // private readonly ILogger<RepositorioController> _logger;
        private readonly IFavoritoService _favoritoService;

        public FavoritoController(IFavoritoService favoritoService)
        {
            _favoritoService = favoritoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RepositorioFavorito>>> GetAll()
        {
            try
            {
                var result = await _favoritoService.GetAll();               
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RepositorioFavorito>> GetById(Int64 Id)
        {
            try
            {
                var result = await _favoritoService.GetById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]        
        public async Task<ActionResult<RepositorioFavorito>> Create([FromBody] List<RepositorioFavorito> repositorioFavoritoList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _favoritoService.Add(repositorioFavoritoList))
                        return CreatedAtAction(nameof(GetAll), repositorioFavoritoList);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete]
        public async Task<ActionResult<RepositorioFavorito>> Delete()
        {
            try
            {
                if (ModelState.IsValid)
                {
                     _favoritoService.RemoveAll();
                    return CreatedAtAction(nameof(GetAll), null);
                }

            return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
