using Webapi_Filmes.Domains;

namespace Webapi_Filmes.Interface
{
    /// <summary>
    /// Interface Responsavel pelo repositorio GeneroRepository
    /// Definir os Metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //TipoRetorno NomeMetodo (tipoParametro  nomeParametro) 
        /// <summary>
        /// Cadastrar um novo Objeto
        /// </summary>
        /// <param name="novoGenero">Objeto que sera Cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns> Lista com os objetos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atuaklizar o objeto existente passando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="genero"> Objeto Atualizado (Novas informacoes)</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar objeto existente passando o seu id pela UrL
        /// </summary>
        /// <param name="id">Id do objeto que sera atualizado  </param>
        /// <param name="genero">Objeto Atualizado (Novas Informacoes)</param>
        void AtualizarIdUrl(int id , GeneroDomain genero);

        /// <summary>
        /// Deletar um Objeto Atraves do seu id
        /// </summary>
        /// <param name="id"> Id do objeto a ser buscado</param>
        void Deletar (int id);


        /// <summary>
        /// Busca um objeto atraves do seu id 
        /// </summary>
        /// <param name="id"> Id do objeto a ser buscado</param>
        /// <returns> Objeto Buscado </returns>
        GeneroDomain BuscarPorId (int id);




    }
}
