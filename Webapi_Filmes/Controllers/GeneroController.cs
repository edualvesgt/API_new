﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi_Filmes.Domains;
using Webapi_Filmes.Interface;
using Webapi_Filmes.Repositories;

namespace Webapi_Filmes.Controllers
{
    //Define que a rota de uma requisicao sera no seguinte formato :
    //Dominio/API/Nome do controller 
    //Exemplo : https://localhost:5000/api/genero
    [Route("api/[controller]")]

    //Define que e um controlador de API
    [ApiController]

    //Defone que o tipo de resposta da API sera no formato JSON
    [Produces("application/json")]

    //Metodo controllador que herda da controller base 
    //Onde sera criado os Endpoints (Rotas)
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que iara receber todos os metodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja refrencia aos metodos do repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }



        /// <summary>
        /// EndPoint que aciona o metodo listartodos no repositorio e retorna a resposta para o usuario (Frnt-end)
        /// </summary>
        /// <returns>Resposta para o usuario </returns>
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                //Cria uma lista que recebe os dados da requisicao 
                List<GeneroDomain> listaGenero = _generoRepository.ListarTodos();

                //Retorna a Lista no formato JSON com status code ok(200)
                return Ok(listaGenero);
            }
            catch (Exception erro)
            {
                //Retorna ym status code BadRequest (400) e a messagem do erro 
                return BadRequest(erro.Message);
            }

            

            

            

        }
    }
}