using System.ComponentModel.DataAnnotations;

namespace Webapi_Filmes.Domains
{

    /// <summary>
    /// Classe que representa a entidade (Tabela) genero
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage ="O Nome do Genero e OBRIGATORIO!!!")]
        public string Nome { get; set; }


        
    }

    
}
