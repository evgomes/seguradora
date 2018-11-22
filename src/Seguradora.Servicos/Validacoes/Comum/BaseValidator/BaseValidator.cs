using FluentValidation;
using Seguradora.Dominio.Sevicos.Validacoes;
using Seguradora.Dominio.Sevicos.Validacoes.Comunicacao;
using Seguradora.Servicos.Validacoes.Extensoes;

namespace Seguradora.Servicos.Validacoes.Comum.BaseValidator
{
    public abstract class BaseValidator<T> : AbstractValidator<T>, IServicoValidacao<T>
    {
        public virtual RespostaValidacao Validar(T entidade)
        {
            var validacao = this.Validate(entidade);

            if (!validacao.IsValid)
            {
                return RespostaValidacao.DadoInvalido(mensagemErroValidacao: validacao.Errors.GetMensagemErro());
            }

            return RespostaValidacao.DadoValido();
        }
    }
}