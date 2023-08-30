using Webapi_Filmes.Domains;

namespace Webapi_Filmes.Interface
{
    public interface IUsuarioRepository
    {
       

         UsuarioDomain Logar(string email , string senha);

    }
}
