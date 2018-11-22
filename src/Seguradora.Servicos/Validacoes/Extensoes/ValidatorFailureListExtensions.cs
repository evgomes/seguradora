using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace Seguradora.Servicos.Validacoes.Extensoes
{
    public static class ValidatorFailureListExtensions
    {
        public static string GetMensagemErro(this IList<ValidationFailure> listaErros)
        {
            var stringBuilder = new StringBuilder();

            foreach (var erro in listaErros)
            {
                stringBuilder.AppendLine(erro.ErrorMessage);
            }

            return stringBuilder.ToString();
        }
    }
}