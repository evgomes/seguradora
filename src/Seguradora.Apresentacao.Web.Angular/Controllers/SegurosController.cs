using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Seguradora.Apresentacao.Web.Angular.Recursos;
using Seguradora.Apresentacao.Web.Angular.Recursos.Base;
using Seguradora.Apresentacao.Web.Angular.Recursos.Seguros;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos.Seguros;

namespace Seguradora.Apresentacao.Web.Angular.Controllers
{
    [Route("/api/[controller]")]
    public class SegurosController : Controller
    {
        private readonly IServicoSeguros _servicoSeguros;
        private readonly IMapper _mapper;

        public SegurosController(IServicoSeguros servicoSeguros, IMapper mapper)
        {
            _servicoSeguros = servicoSeguros;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAsync([FromQuery] byte tipoSeguro = 0)
        {
            if(tipoSeguro < 0 || tipoSeguro > 3) {
                return BadRequest(new RespostaJson { Sucesso = false, Mensagem = "Tipo inválido de seguro especificado." });
            }
            
            var tipoSeguroEnum = tipoSeguro == 0 ? (ETipoSeguro?)null : (ETipoSeguro?)tipoSeguro;

            var requisicao = new RequisicaoListagemSeguros(tipoSeguro: tipoSeguroEnum);
            var resposta = await _servicoSeguros.ListarAsync(requisicao);

            if (tipoSeguroEnum == null)
                return Ok(_mapper.Map<SegurosResposta, RespostaJsonGenerica<IEnumerable<RecursoSeguro>>>(resposta));

            switch (tipoSeguroEnum.Value)
            {
                case ETipoSeguro.Automovel:
                    return Ok(_mapper.Map<SegurosResposta, RespostaJsonGenerica<IEnumerable<RecursoSeguradoVeiculo>>>(resposta));
                case ETipoSeguro.Residencial:
                    return Ok(_mapper.Map<SegurosResposta, RespostaJsonGenerica<IEnumerable<RecursoSeguradoResidencia>>>(resposta));
                case ETipoSeguro.Vida:
                default:
                    return Ok(_mapper.Map<SegurosResposta, RespostaJsonGenerica<IEnumerable<RecursoSeguradoVida>>>(resposta));
            }
        }

        [HttpGet]
        [Route("/api/[controller]/tipos")]
        public IActionResult ListarTiposSeguros()
        {
            var resposta = _servicoSeguros.ListaTiposSeguros();
            return Ok(_mapper.Map<TiposSeguroResposta, RespostaJsonGenerica<IEnumerable<RecursoTipoSeguro>>>(resposta));
        }
    }
}