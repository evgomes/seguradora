using FluentValidation;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Servicos.Validacoes.Comum.BaseValidator;

namespace Seguradora.Servicos.Validacoes.Seguros
{
    public abstract class ServicoValidacaoSeguros : BaseValidator<Seguro>
    {
        protected ServicoValidacaoSeguros()
        {
            RuleFor(s => s.CpfCnpj).NotNull().NotEmpty().MinimumLength(11).MaximumLength(14);
            RuleFor(s => s.Tipo).NotNull();
            RuleFor(s => s.SeguroSegurado).NotNull();
        }
    }
}