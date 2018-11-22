using FluentValidation;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos.Validacoes;
using Seguradora.Dominio.Sevicos.Validacoes.Comunicacao;
using Seguradora.Servicos.Validacoes.Comum.BaseValidator;

namespace Seguradora.Servicos.Validacoes.Seguros
{
    public class ServicoValidacaoSegurosResidenciais : ServicoValidacaoSeguros
    {
        public ServicoValidacaoSegurosResidenciais() : base()
        {
            
            RuleFor(s => s.SeguroSegurado.Residencia).NotNull();
            RuleFor(s => s.SeguroSegurado.Residencia.Rua).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(s => s.SeguroSegurado.Residencia.Bairro).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(s => s.SeguroSegurado.Residencia.Cidade).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}