using System.Data.SqlClient;
using Webapi_Filmes.Domains;
using Webapi_Filmes.Interface;

namespace Webapi_Filmes.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE15-S15; initial Catalog = Filmes; User Id = sa; pwd = Senai@134";


        public UsuarioDomain Logar(string email, string senha)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT Email , Senha  , Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain user = new UsuarioDomain()
                        {
                            Email = rdr["Email"].ToString(),

                            Senha = rdr["Senha"].ToString(),

                            Permissao = rdr["Permissao"].ToString()
                        };

                        return user;

                        
                    }

                    return null;
                    
                }
            }
        }
    }
}
