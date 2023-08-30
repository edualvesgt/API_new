using System.ComponentModel.DataAnnotations;

namespace Webapi_Filmes.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Email Obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Senha Obrigatoria")]
        public string Senha { get; set; }

        public string Permissao { get; set; }
    }
}
