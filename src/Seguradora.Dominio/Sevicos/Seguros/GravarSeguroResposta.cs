using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos.Comunicacao;

namespace Seguradora.Dominio.Sevicos.Seguros
{
    public class GravarSeguroResposta : BaseResposta
    {
        public Seguro Seguro { get; set; }

        private GravarSeguroResposta(bool successo, string mensagem, Seguro seguro) : base(successo, mensagem)
        {
            this.Seguro = seguro;
        }

        public static GravarSeguroResposta CriarSucesso(Seguro seguro)
        {
            return new GravarSeguroResposta(true, string.Empty, seguro);
        }

        public static GravarSeguroResposta CriarFalha(string mensagem)
        {
            return new GravarSeguroResposta(false, mensagem, null);
        }
    }
}