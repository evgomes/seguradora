using System;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos.Validacoes;

namespace Seguradora.Servicos.Validacoes.Seguros
{
    public static class ServicoValidacaoSegurosFactory
    {
        public static IServicoValidacao<Seguro> GetServicoPara(ETipoSeguro tipoSeguro)
        {
            switch(tipoSeguro)
            {
                case ETipoSeguro.Automovel:
                    return new ServicoValidacaoSegurosVeiculos();
                case ETipoSeguro.Residencial:
                    return new ServicoValidacaoSegurosResidenciais();
                case ETipoSeguro.Vida:
                    return new ServicoValidacaoSegurosVida();
                default:
                    throw new NotImplementedException("Serviço de validação de seguros não implementado para o tipo de seguro em questão.");
            }
        }
    }
}