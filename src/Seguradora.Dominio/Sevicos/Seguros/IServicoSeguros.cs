using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seguradora.Dominio.Sevicos.Seguros
{
    public interface IServicoSeguros
    {
         Task<SegurosResponse> Listar(ListagemSegurosRequest requisicao);
    }
}