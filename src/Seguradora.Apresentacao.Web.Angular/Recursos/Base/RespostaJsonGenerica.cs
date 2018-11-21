namespace Seguradora.Apresentacao.Web.Angular.Recursos.Base
{
    public class RespostaJsonGenerica<T> : RespostaJson
    {
        public T Dados { get; set; }
    }
}