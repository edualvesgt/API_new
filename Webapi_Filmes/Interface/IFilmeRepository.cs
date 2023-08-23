using Webapi_Filmes.Domains;

namespace Webapi_Filmes.Interface
{
    public interface IFilmeRepository
    {
        //TipoRetorno NomeMetodo (tipoParametro  nomeParametro) 
        /// <summary>
        /// Cadastrar um novo Objeto
        /// </summary>
        /// <param name="novoFilme">Objeto que sera Cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns> Lista com os objetos</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Atuaklizar o objeto existente passando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="filme"> Objeto Atualizado (Novas informacoes)</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualizar objeto existente passando o seu id pela UrL
        /// </summary>
        /// <param name="id">Id do objeto que sera atualizado  </param>
        /// <param name="filme">Objeto Atualizado (Novas Informacoes)</param>
        void AtualizarIdUr(int id, FilmeDomain filme);

        /// <summary>
        /// Deletar um Objeto Atraves do seu id
        /// </summary>
        /// <param name="id"> Id do objeto a ser buscado</param>
        void Deletar(int id);


        /// <summary>
        /// Busca um objeto atraves do seu id 
        /// </summary>
        /// <param name="id"> Id do objeto a ser buscado</param>
        /// <returns> Objeto Buscado </returns>
        FilmeDomain BuscarPorId (int id);

    }
}
