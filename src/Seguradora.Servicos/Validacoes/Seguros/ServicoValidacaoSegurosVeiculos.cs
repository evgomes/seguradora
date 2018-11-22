using System.Text.RegularExpressions;
using FluentValidation;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos.Validacoes.Comunicacao;

namespace Seguradora.Servicos.Validacoes.Seguros
{
    public class ServicoValidacaoSegurosVeiculos : ServicoValidacaoSeguros
    {
        public ServicoValidacaoSegurosVeiculos() : base()
        {
            RuleFor(s => s.SeguroSegurado.Veiculo).NotNull();
            RuleFor(s => s.SeguroSegurado.Veiculo.Placa).NotNull().NotEmpty().MinimumLength(7).MaximumLength(7);
        }

        public override RespostaValidacao Validar(Seguro seguro)
        {
            var resposta = base.Validar(seguro);

            if(!resposta.Valido)
            {
                return resposta;
            }

            var regexPlacaValida = new Regex(@"^\w{3}\d{4}$", RegexOptions.IgnoreCase);
            var placaValida = regexPlacaValida.IsMatch(seguro.SeguroSegurado.Veiculo.Placa);

            if(!placaValida)
            {
                return RespostaValidacao.DadoInvalido("A placa é inválida.");
            }

            return resposta;
        }
    }
}