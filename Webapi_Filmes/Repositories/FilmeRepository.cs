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

        public object Genero { get; private set; }

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateById = "UPDATE Filme SET Filme.IdGenero = @IdGenero, Titulo = @Titulo  WHERE IdFilme = @IdFIlme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand (queryUpdateById, con ))
                {
                    cmd.Parameters.AddWithValue ("@IdFilme", id);
                    cmd.Parameters.AddWithValue ("@Titulo", filme.TituloFilme);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.Genero.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {


            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT IdFilme , Titulo, Genero.Nome, Genero.IdGenero FROM Filme LEFT JOIN Genero ON Filme.IdGenero = Genero.IdGenero WHERE IdFilme = @id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);


                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {

                        FilmeDomain buscaFilme = new FilmeDomain()
                        {

                            TituloFilme = rdr["Titulo"].ToString(),
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            
                            Genero = new GeneroDomain()
                            {
                                Nome = rdr["Nome"].ToString(),
                                IdGenero = Convert.ToInt32(rdr["IdGenero"])
                            }



                        };



                    return buscaFilme;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Filme (Titulo, IdGenero)  VALUES (@Titulo, @IdGenero)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("Titulo", novoFilme.TituloFilme);

                    cmd.Parameters.AddWithValue("@Idgenero", novoFilme.Genero.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE Filme WHERE IdFilme = @id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

            }
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
