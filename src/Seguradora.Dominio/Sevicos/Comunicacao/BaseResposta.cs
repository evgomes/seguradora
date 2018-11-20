namespace Seguradora.Dominio.Sevicos.Comunicacao
{
    /// <summary>
    /// Classe base para respostas a solicitações de serviços.
    /// </summary>
    public abstract class BaseResposta
    {
        /// <summary>
        /// Indica se a solicitação foi bem-sucedida ou não.
        /// </summary>
        public bool Successo { get; protected set; }

        /// <summary>
        /// Mensagem de retorno, quando for o caso.
        /// </summary>
        public string Mensagem { get; protected set; }

        public BaseResposta(bool successo, string mensagem)
        {
            Successo = successo;
            Mensagem = mensagem;
        }
    }
}