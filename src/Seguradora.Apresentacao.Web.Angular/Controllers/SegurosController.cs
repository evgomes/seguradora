using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Seguradora.Apresentacao.Web.Angular.Extensoes;
using Seguradora.Apresentacao.Web.Angular.Recursos;
using Seguradora.Apresentacao.Web.Angular.Recursos.Base;
using Seguradora.Apresentacao.Web.Angular.Recursos.Seguros;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos.Seguros;

namespace Seguradora.Apresentacao.Web.Angular.Controllers
{
    /// <summary>
    /// Controller para gerenciamento de seguros.
    /// </summary>
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

        /// <summary>
        /// Lista os seguros cadastrados no sistema de acordo com o tipo de segudo.
        /// </summary>
        /// <param name="tipoSeguro">Código do tipo de seguro. 0 - todos; 1 - automóveis; 2 - residenciais; 3 - seguros de vida</param>
        /// <returns>Resposta contendo dados de seguros.</returns>
        [HttpGet]
        public async Task<IActionResult> ListarAsync([FromQuery] byte tipoSeguro = 0)
        {
            if (tipoSeguro < 0 || tipoSeguro > 3)
            {
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

        /// <summary>
        /// Listar um seguro de acordo com seu código.
        /// </summary>
        /// <param name="id">Código do seguro.</param>
        /// <returns>Resposta com o seguro.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeguroAsync(int id)
        {
            var seguro = await _servicoSeguros.GetAsync(id);

            if (seguro == null)
            {
                return NotFound(new RespostaJson { Sucesso = false, Mensagem = "Seguro não encontrado." });
            }

            switch (seguro.Tipo)
            {
                case ETipoSeguro.Automovel:
                    return Ok(_mapper.Map<Seguro, RespostaJsonGenerica<RecursoSeguradoVeiculo>>(seguro));
                case ETipoSeguro.Residencial:
                    return Ok(_mapper.Map<Seguro, RespostaJsonGenerica<RecursoSeguradoResidencia>>(seguro));
                case ETipoSeguro.Vida:
                default:
                    return Ok(_mapper.Map<Seguro, RespostaJsonGenerica<RecursoSeguradoVida>>(seguro));
            }
        }

        /// <summary>
        /// Lista os tipos de seguro.
        /// </summary>
        /// <returns>Resposta com os tipos de seguro.</returns>
        [HttpGet]
        [Route("/api/[controller]/tipos")]
        public IActionResult ListarTiposSeguros()
        {
            var resposta = _servicoSeguros.ListaTiposSeguros();
            return Ok(_mapper.Map<TiposSeguroResposta, RespostaJsonGenerica<IEnumerable<RecursoTipoSeguro>>>(resposta));
        }

        /// <summary>
        /// Grava um novo seguro na base de dados.
        /// </summary>
        /// <param name="recursoSalvarSeguro">Recurso com os dados para gravação do seguro.</param>
        /// <returns>Resposta da gravação.</returns>
        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] RecursoSalvarSeguro recursoSalvarSeguro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RespostaJson { Sucesso = false, Mensagem = ModelState.GetMensagemErro() });
            }

            var seguro = _mapper.Map<RecursoSalvarSeguro, Seguro>(recursoSalvarSeguro);
            var resultado = await _servicoSeguros.CriarAsync(seguro);

            if (!resultado.Sucesso)
            {
                return BadRequest(new RespostaJson { Sucesso = false, Mensagem = resultado.Mensagem });
            }

            var resposta = _mapper.Map<GravarSeguroResposta, RespostaJsonGenerica<RecursoSeguro>>(resultado);
            return Ok(resposta);
        }

        /// <summary>
        /// Atualiza um seguro existente.
        /// </summary>
        /// <param name="id">Código do seguro.</param>
        /// <param name="recursoSalvarSeguro">Recurso com os dados para gravação do seguro.</param>
        /// <returns>Resposta da gravação.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] RecursoSalvarSeguro recursoSalvarSeguro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RespostaJson { Sucesso = false, Mensagem = ModelState.GetMensagemErro() });
            }

            var seguro = _mapper.Map<RecursoSalvarSeguro, Seguro>(recursoSalvarSeguro);
            var resultado = await _servicoSeguros.AtualizarAsync(id, seguro);

            if (!resultado.Sucesso)
            {
                return BadRequest(new RespostaJson { Sucesso = false, Mensagem = resultado.Mensagem });
            }

            var resposta = _mapper.Map<GravarSeguroResposta, RespostaJsonGenerica<RecursoSeguro>>(resultado);
            return Ok(resposta);
        }

        /// <summary>
        /// Exclui um seguro do sistema.
        /// </summary>
        /// <param name="id">Código do seguro.</param>
        /// <returns>Resposta da requisição.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirAsync(int id)
        {
            var resultado = await _servicoSeguros.ExcluirAsync(id);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.Mensagem);
            }

            var resposta = _mapper.Map<GravarSeguroResposta, RespostaJsonGenerica<RecursoSeguro>>(resultado);
            return Ok(resposta);
        }
    }
}