using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seguradora.Dominio.Models.Segurados;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Servicos.Validacoes.Seguros;

namespace Seguradora.Testes.Servicos.Validacoes.Seguros
{
    [TestClass]
    public class ServicoValidacaoSegurosVeiculosTestes
    {
        [TestMethod]
        public void Deve_Retornar_Valido_Para_Seguro_Veiculo_Valido()
        {
            var seguro = new Seguro
            {
                CpfCnpj = "11122233344",
                Tipo = ETipoSeguro.Residencial,
                SeguroSegurado = new SeguroSegurado
                {
                    Veiculo = new Veiculo
                    {
                        Placa = "AAA1111"
                    }
                }
            };

            var servicoValidacao = new ServicoValidacaoSegurosVeiculos();
            var resultado = servicoValidacao.Validar(seguro);

            Assert.IsTrue(resultado.Valido);
        }

        [TestMethod]
        public void Deve_Retornar_Invalido_Para_Seguro_Veiculo_Invalido()
        {
            var seguro = new Seguro
            {
                CpfCnpj = "11122233344",
                Tipo = ETipoSeguro.Residencial,
                SeguroSegurado = new SeguroSegurado
                {
                    Veiculo = new Veiculo
                    {
                        Placa = "111AAAA"
                    }
                }
            };

            var servicoValidacao = new ServicoValidacaoSegurosVeiculos();
            var resultado = servicoValidacao.Validar(seguro);

            Assert.IsFalse(resultado.Valido);
        }
    }
}