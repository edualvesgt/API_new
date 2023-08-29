using System.Data.SqlClient;
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
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT * FROM Filme INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero;";
                ;

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            TituloFilme = rdr["Titulo"].ToString(),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                                Nome = rdr["Nome"].ToString()
                            }

                    };




                    ListaFilmes.Add(filme);
                }

            }

        }

            return ListaFilmes;
        }
}
}
