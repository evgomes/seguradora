using System.Collections.Generic;
using System.Threading.Tasks;
using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Dominio.Sevicos.Seguros
{
    public interface IServicoSeguros
    {
         Task<SegurosResposta> ListarAsync(RequisicaoListagemSeguros requisicao);
         TiposSeguroResposta ListaTiposSeguros();
    }
}