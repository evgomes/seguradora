namespace Seguradora.Dominio.Sevicos.Validacoes.Comunicacao
{
    public class RespostaValidacao
    {
        public bool Valido { get; private set; }
        public string Mensagem { get; private set; }

        protected RespostaValidacao(bool valido, string mensagem)
        {
            this.Valido = valido;
            this.Mensagem = mensagem;
        }

        public static RespostaValidacao DadoValido()
        {
            return new RespostaValidacao(valido: true, mensagem: string.Empty);
        }

        public static RespostaValidacao DadoInvalido(string mensagemErroValidacao)
        {
            return new RespostaValidacao(valido: false, mensagem: mensagemErroValidacao);
        }
    }
}