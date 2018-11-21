using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Repositorios.Seguros;
using Seguradora.Dominio.Sevicos.Seguros;

namespace Seguradora.Servicos.Seguros
{
    public class ServicoSeguros : IServicoSeguros
    {
        private readonly IRepositorioSeguros _repositorioSeguros;

        public ServicoSeguros(IRepositorioSeguros repositorioSeguros)
        {
            _repositorioSeguros = repositorioSeguros;
        }

        public async Task<SegurosResposta> ListarAsync(RequisicaoListagemSeguros requisicao)
        {
            try
            {
                var seguros = await _repositorioSeguros.ListarAsync(requisicao.TipoSeguro);
                return SegurosResposta.CriarSucesso(seguros);
            }
            catch(Exception ex)
            {
                return SegurosResposta.CriarFalha($"Não foi possível listar os seguros: {ex.Message}.");
            }
        }

        public TiposSeguroResposta ListaTiposSeguros()
        {
            var tiposSeguros = new List<ETipoSeguro>();

            foreach(var @enum in Enum.GetValues(typeof(ETipoSeguro)))
            {
                tiposSeguros.Add((ETipoSeguro)@enum);
            }

            return new TiposSeguroResposta(sucesso: true, mensagem: string.Empty, tiposSeguros: tiposSeguros);
        }
    }
}