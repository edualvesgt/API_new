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
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
                using (SqlCommand cmd = new SqlCommand(QuerySelectAll,Con))
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
    }
}
