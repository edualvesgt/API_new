using System.Data.SqlClient;
using System.Runtime.Serialization;
using Webapi_Filmes.Domains;
using Webapi_Filmes.Interface;

namespace Webapi_Filmes.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// string de conexao com o banco de dados que recebe os seguintes parametro 
        /// Data source =  nome do servidor 
        /// initial catalog = Nome do banco de dados
        /// Autenticacao = 
        ///        - Windowns  : Integrated security = true 
        ///        - SqlServer : User Id = sa; Pwd : Senha 
        /// </summary>
        private string StringConexao = "Data Source = NOTE15-S15; initial Catalog = Filmes; User Id = sa; pwd = Senai@134";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUr(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdatebyId = "UPDATE Genero SET Nome = @nome  WHERE IdGenero = @id ";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdatebyId, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.Parameters.AddWithValue("@genero", genero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {

       
            //Declara a string de conexaso como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string querySelectId = "SELECT IdGenero , Nome FROM Genero WHERE IdGenero = @id";

                //Abre a conexao com o banco de dados 
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que sera executada e a conexao do banco 
                using (SqlCommand cmd = new SqlCommand(querySelectId, con))
                {

                    ///Passa o valor do parametro 
                    cmd.Parameters.AddWithValue("@id", id);

                    //Executar a query (querySelectId)
                    rdr = cmd.ExecuteReader();


                    if (rdr.Read())
                    {
                        GeneroDomain busca = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString()
                        };

                        return busca;
                    }

                    return null;
                }

                

            }

            
        }



        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto Com as informacoes que serao cadastradas</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a string de conexaso como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string queryInsert = "INSERT INTO Genero(Nome)  VALUES (@Nome)";

                //Abre a conexao com o banco de dados 
                con.Open();


                //Declara o SqlCommand passando a query que sera executada e a conexao do banco 
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    ////Passa o valor do parametro 
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();

                }


            }
        }


        /// <summary>
        /// Metodo Para listar todos os Obejetos Generos 
        /// </summary>
        /// <returns> Lista de Objetos </returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de objetos do tipo genero
            List<GeneroDomain> ListaGenero = new List<GeneroDomain>();

            //Declara a SqlConnection passando a string de conexao como parametro 
            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                //Declara a instrucao a ser executada
                string QuerySelectAll = "SELECT IdGenero , Nome FROM Genero";

                //Abre a conexao com o banco de dados
                Con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que sera executada e a conexao com o banco de dados 
                using (SqlCommand cmd = new SqlCommand(QuerySelectAll, Con))
                {
                    //Executa a query e armazena os dados do rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propiedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propiedade Nome o valor a ser recebido no rdr 
                            Nome = Convert.ToString(rdr["Nome"])
                        };

                        //Adiciona Cada objeto Dentro da sua lista
                        ListaGenero.Add(genero);
                    }
                }

            }

            return ListaGenero;
        }






        public void Deletar(int id)
        {
            //Declara a string de conexaso como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string queryDelete = "DELETE FROM Genero   WHERE @id = IdGenero";

                //Abre a conexao com o banco de dados 
                con.Open();

                //Declara o SqlCommand passando a query que sera executada e a conexao do banco 
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    ////Passa o valor do parametro 
                    cmd.Parameters.AddWithValue("@id", id);

                    //Executar a query (queryDelete)
                    cmd.ExecuteNonQuery();

                }


            }
        }

    }
}
