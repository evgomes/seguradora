using System.Collections.Generic;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos.Comunicacao;

namespace Seguradora.Dominio.Sevicos.Seguros
{
    public class TiposSeguroResposta : BaseResposta
    {
        public IEnumerable<ETipoSeguro> TiposSeguros { get; set; }

        public TiposSeguroResposta(bool sucesso, string mensagem, IEnumerable<ETipoSeguro> tiposSeguros) : base(sucesso, mensagem)
        { 
            this.TiposSeguros = tiposSeguros;
        }
    }
}