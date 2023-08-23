using Webapi_Filmes.Domains;
using Webapi_Filmes.Interface;

namespace Webapi_Filmes.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// string de conexao com o banco de dados que recebe os seguintes parametro 
        /// Data source =  nome do servidor 
        /// initial catalog = Nome do banco de dados
        /// Autenticacao = 
        ///          -Windowns  : Integrated security = true 
        ///          -SqlServer : User Id = sa; Pwd : Senha 
        /// </summary>
        private string StringConexao = "Data Source = NOTE15-S15; initial Catalog = Filmes; User Id = sa; pwd = Senai@134";
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUr(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
