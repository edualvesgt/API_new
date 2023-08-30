using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi_Filmes.Domains;
using Webapi_Filmes.Interface;
using Webapi_Filmes.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public IActionResult Get()
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

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)

        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);

            }
        }


        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            try
            {
                FilmeDomain busca = _filmeRepository.BuscarPorId(id);

                if (busca == null)
                {
                    return NotFound("Nenhum Filme Encontrado");
                }

                return Ok(busca);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


        [HttpPut("{id}")]

        public IActionResult PutById(FilmeDomain filme, int id)
        {
            FilmeDomain busca = _filmeRepository.BuscarPorId(id);

            try
            {

                if (busca == null)
                {
                    return NotFound("Nenhum Filme Encontrado");
                }

                else
                {
                    _filmeRepository.AtualizarIdUrl(id, filme);
                    return StatusCode(200);
                }
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }


        [HttpPut]

        public IActionResult PutByBody (FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarIdCorpo(filme);
                return StatusCode(200, filme);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
