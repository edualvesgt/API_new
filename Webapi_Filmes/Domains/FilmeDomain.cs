using System.ComponentModel.DataAnnotations;

namespace Webapi_Filmes.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage ="O Titulo do filme deve ser Informado!!!")]
        public string TituloFilme { get; set;}



        //Referencia para a classe genero 
        public GeneroDomain Genero { get; set; } 
    }
}
