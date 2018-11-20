using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos;
using Seguradora.Dominio.Sevicos.Seguros;

namespace Seguradora.Apresentacao.Web.Controllers
{
    [Route("/[controller]/[action]")]
    public class SegurosController : Controller
    {
        private readonly IServicoSeguros _servicoSeguros;

        public SegurosController(IServicoSeguros servicoSeguros)
        {
            _servicoSeguros = servicoSeguros;
        }

        public async Task<JsonResult> Listar(ETipoSeguro? tipoSeguro)
        {
            var requisicao = new ListagemSegurosRequest(tipoSeguro: tipoSeguro);
            var resposta = await _servicoSeguros.Listar(requisicao);

            if(!resposta.Successo) {
                ModelState.AddModelError("listagem-seguros", resposta.Mensagem);
                return Json("");
            }

            return Json(resposta.Seguros);
        }
    }
}