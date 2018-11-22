using Seguradora.Dominio.Sevicos.Validacoes.Comunicacao;

namespace Seguradora.Dominio.Sevicos.Validacoes
{
    public interface IServicoValidacao<T>
    {
        RespostaValidacao Validar(T entidade);
    }
}