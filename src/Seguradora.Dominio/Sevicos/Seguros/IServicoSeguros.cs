using System.Collections.Generic;
using System.Threading.Tasks;
using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Dominio.Sevicos.Seguros
{
    public interface IServicoSeguros
    {
        Task<SegurosResposta> ListarAsync(RequisicaoListagemSeguros requisicao);
        TiposSeguroResposta ListaTiposSeguros();
        Task<Seguro> GetAsync(int id);
        Task<GravarSeguroResposta> CriarAsync(Seguro seguro);
        Task<GravarSeguroResposta> AtualizarAsync(int id, Seguro seguro);
        Task<GravarSeguroResposta> ExcluirAsync(int id);
    }
}