using System.Collections.Generic;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos.Comunicacao;

namespace Seguradora.Dominio.Sevicos.Seguros
{
    public class SegurosResposta : BaseResposta
    {
        public IEnumerable<Seguro> Seguros { get; set; }

        private SegurosResposta(bool successo, string mensagem, IEnumerable<Seguro> seguros) : base(successo, mensagem)
        { 
            this.Seguros = seguros;
        }

        public static SegurosResposta CriarSucesso(IEnumerable<Seguro> seguros)
        {
            return new SegurosResposta(true, string.Empty, seguros);
        }

        public static SegurosResposta CriarFalha(string mensagem)
        {
            return new SegurosResposta(false, mensagem, null);
        }
    }
}