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

    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }

        
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]

        public IActionResult Login (string email , string senha)
        {
            try
            {
                UsuarioDomain user = _usuarioRepository.Logar(email, senha);

                if (user == null )
                {
                    return NotFound("Nenhum Usuario encontrado");
                }

                return Ok(user);

            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
