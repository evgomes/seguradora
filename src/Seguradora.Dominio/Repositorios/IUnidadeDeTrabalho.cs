using System.Threading.Tasks;

namespace Seguradora.Dominio.Repositorios
{
    /// <summary>
    /// Uso do design pattern "unit of work" para gerenciar transações na base de dados.
    /// </summary>
    public interface IUnidadeDeTrabalho
    {
        /// <summary>
        /// Completa uma transação.
        /// </summary>
        /// <returns>Task.</returns>
        Task CompletarAsync();
    }
}