using System.Collections.Generic;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos.Comunicacao;

namespace Seguradora.Dominio.Sevicos.Seguros
{
    public class SegurosResponse : BaseResposta
    {
        public IEnumerable<Seguro> Seguros { get; set; }

        private SegurosResponse(bool successo, string mensagem, IEnumerable<Seguro> seguros) : base(successo, mensagem)
        { 
            this.Seguros = seguros;
        }

        public static SegurosResponse CriarSucesso(IEnumerable<Seguro> seguros)
        {
            return new SegurosResponse(true, null, seguros);
        }

        public static SegurosResponse CriarFalha(string mensagem)
        {
            return new SegurosResponse(false, mensagem, null);
        }
    }
}