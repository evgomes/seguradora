using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Seguradora.Apresentacao.Web.Angular.Extensoes
{
    public static class ModelStateDictionaryExtensions
    {
        public static string GetMensagemErro(this ModelStateDictionary modelState)
        {
            return string.Join("; ", modelState.Values.SelectMany(x => x.Errors)
                                                      .Select(x => x.ErrorMessage));
        }
    }
}