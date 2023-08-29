using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi_Filmes.Domains;
using Webapi_Filmes.Interface;
using Webapi_Filmes.Repositories;

namespace Webapi_Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Defone que o tipo de resposta da API sera no formato JSON
    [Produces("application/json")]


    public class FilmeController : ControllerBase
    {
        /// <summary>
        /// Objeto _filmeRepository que iara receber todos os metodos definidos na interface IFilmeRepository
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _filmeRepository para que haja refrencia aos metodos do repositorio
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet]

        public IActionResult Get () 
        {
            try
            {
                List<FilmeDomain> listaFilme = _filmeRepository.ListarTodos();
                return Ok(listaFilme);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);

            }
        }

    }
}
