using FluentValidation;

namespace Seguradora.Servicos.Validacoes.Seguros
{
    public class ServicoValidacaoSegurosVida : ServicoValidacaoSeguros
    {
        public ServicoValidacaoSegurosVida() : base()
        {
            RuleFor(s => s.SeguroSegurado.Vida).NotNull();
            RuleFor(s => s.SeguroSegurado.Vida.Cpf).NotNull().NotEmpty().MinimumLength(11).MaximumLength(11);
        }
    }
}