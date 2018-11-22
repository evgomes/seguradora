using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Repositorios;
using Seguradora.Dominio.Repositorios.Seguros;
using Seguradora.Dominio.Sevicos.Seguros;
using Seguradora.Dominio.Sevicos.Validacoes;
using Seguradora.Dominio.Sevicos.Validacoes.Comunicacao;
using Seguradora.Servicos.Validacoes.Seguros;

namespace Seguradora.Servicos.Seguros
{
    public class ServicoSeguros : IServicoSeguros
    {
        private readonly IRepositorioSeguros _repositorioSeguros;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

        public ServicoSeguros(IRepositorioSeguros repositorioSeguros, IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _repositorioSeguros = repositorioSeguros;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }

        public async Task<SegurosResposta> ListarAsync(RequisicaoListagemSeguros requisicao)
        {
            try
            {
                var seguros = await _repositorioSeguros.ListarAsync(requisicao.TipoSeguro);
                return SegurosResposta.CriarSucesso(seguros);
            }
            catch (Exception ex)
            {
                return SegurosResposta.CriarFalha($"Não foi possível listar os seguros: {ex.Message}.");
            }
        }

        public TiposSeguroResposta ListaTiposSeguros()
        {
            var tiposSeguros = new List<ETipoSeguro>();

            foreach (var @enum in Enum.GetValues(typeof(ETipoSeguro)))
            {
                tiposSeguros.Add((ETipoSeguro) @enum);
            }

            return new TiposSeguroResposta(sucesso: true, mensagem: string.Empty, tiposSeguros: tiposSeguros);
        }

        public async Task<Seguro> GetAsync(int id)
        {
            return await _repositorioSeguros.GetAsync(id);
        }

        public async Task<GravarSeguroResposta> CriarAsync(Seguro seguro)
        {
            try
            {
                var respostaValidacaoSeguro = ValidarSeguro(seguro);
                if (!respostaValidacaoSeguro.Valido)
                {
                    return GravarSeguroResposta.CriarFalha(respostaValidacaoSeguro.Mensagem);
                }

                await _repositorioSeguros.AdicionarAsync(seguro);
                await _unidadeDeTrabalho.CompletarAsync();

                return GravarSeguroResposta.CriarSucesso(seguro);
            }
            catch (Exception ex)
            {
                return GravarSeguroResposta.CriarFalha($"Não foi possível gravar o seguro: {ex.Message}.");
            }
        }

        public async Task<GravarSeguroResposta> AtualizarAsync(int id, Seguro seguro)
        {
            try
            {
                var seguroExistente = await _repositorioSeguros.GetAsync(id);

                if (seguroExistente == null)
                {
                    return GravarSeguroResposta.CriarFalha("Seguro não encontrado na base de dados para atualização.");
                }

                seguroExistente.CpfCnpj = seguro.CpfCnpj;
                PopularDadosTipoSeguro(seguro, seguroExistente);

                var respostaValidacaoSeguro = ValidarSeguro(seguroExistente);
                if (!respostaValidacaoSeguro.Valido)
                {
                    return GravarSeguroResposta.CriarFalha(respostaValidacaoSeguro.Mensagem);
                }

                _repositorioSeguros.Atualizar(seguroExistente);
                await _unidadeDeTrabalho.CompletarAsync();

                return GravarSeguroResposta.CriarSucesso(seguroExistente);
            }
            catch (Exception ex)
            {
                return GravarSeguroResposta.CriarFalha($"Não foi possível gravar o seguro: {ex.Message}.");
            }
        }

        public async Task<GravarSeguroResposta> ExcluirAsync(int id)
        {
            var seguroExistente = await _repositorioSeguros.GetAsync(id);

            if (seguroExistente == null)
            {
                return GravarSeguroResposta.CriarFalha("Seguro não encontrado na base de dados para exclusão.");
            }

            try
            {
                _repositorioSeguros.Excluir(seguroExistente);
                await _unidadeDeTrabalho.CompletarAsync();

                return GravarSeguroResposta.CriarSucesso(seguroExistente);
            }
            catch (Exception ex)
            {
                return GravarSeguroResposta.CriarFalha(ex.Message);
            }
        }

        public RespostaValidacao ValidarSeguro(Seguro seguro)
        {
            if (seguro == null)
            {
                return RespostaValidacao.DadoInvalido("O seguro está nullo.");
            }

            IServicoValidacao<Seguro> servicoValidacao = ServicoValidacaoSegurosFactory.GetServicoPara(seguro.Tipo);
            return servicoValidacao.Validar(seguro);
        }

        private void PopularDadosTipoSeguro(Seguro origem, Seguro destino)
        {
            switch (origem.Tipo)
            {
                case ETipoSeguro.Automovel:
                    PopularDadosSeguroAutomovel(origem, destino);
                    break;
                case ETipoSeguro.Residencial:
                    PopularDadosSeguroResidencial(origem, destino);
                    break;
                case ETipoSeguro.Vida:
                default:
                    PopularDadosSeguroVida(origem, destino);
                    break;
            }
        }

        private void PopularDadosSeguroVida(Seguro origem, Seguro destino)
        {
            origem.SeguroSegurado.Vida.Cpf = destino.SeguroSegurado.Vida.Cpf;
        }

        private void PopularDadosSeguroAutomovel(Seguro origem, Seguro destino)
        {
            origem.SeguroSegurado.Veiculo.Placa = destino.SeguroSegurado.Veiculo.Placa;
        }

        private void PopularDadosSeguroResidencial(Seguro origem, Seguro destino)
        {
            origem.SeguroSegurado.Residencia.Rua = destino.SeguroSegurado.Residencia.Rua;
            origem.SeguroSegurado.Residencia.Numero = destino.SeguroSegurado.Residencia.Numero;
            origem.SeguroSegurado.Residencia.Bairro = destino.SeguroSegurado.Residencia.Bairro;
            origem.SeguroSegurado.Residencia.Cidade = destino.SeguroSegurado.Residencia.Cidade;
        }
    }
}