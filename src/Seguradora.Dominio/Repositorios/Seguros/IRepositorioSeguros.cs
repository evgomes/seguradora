using System.Collections.Generic;
using System.Threading.Tasks;
using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Dominio.Repositorios.Seguros
{
    public interface IRepositorioSeguros
    {
        Task<IEnumerable<Seguro>> ListarAsync(ETipoSeguro? tipo);
        Task<Seguro> GetAsync(int id);
        Task AdicionarAsync(Seguro seguro);
        void Atualizar(Seguro seguro);
        void Excluir(Seguro seguro);
    }
}