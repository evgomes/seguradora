using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seguradora.Dominio.Models.Segurados;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Servicos.Validacoes.Seguros;

namespace Seguradora.Testes.Servicos.Validacoes.Seguros
{
    [TestClass]
    public class ServicoValidacaoSegurosResidenciaisTestes
    {
        [TestMethod]
        public void Deve_Retornar_Valido_Para_Seguro_Residencial_Valido()
        {
            var seguro = new Seguro
            {
                CpfCnpj = "11122233344",
                Tipo = ETipoSeguro.Residencial,
                SeguroSegurado = new SeguroSegurado
                {
                    Residencia = new Residencia
                    {
                        Rua = "Teste",
                        Bairro = "Teste",
                        Cidade = "Teste"
                    }
                }
            };

            var servicoValidacao = new ServicoValidacaoSegurosResidenciais();
            var resultado = servicoValidacao.Validar(seguro);

            Assert.IsTrue(resultado.Valido);
        }

        [TestMethod]
        public void Deve_Retornar_Invalido_Para_Seguro_Residencial_Invalido()
        {
            var seguro = new Seguro
            {
                CpfCnpj = "11122233344",
                Tipo = ETipoSeguro.Residencial,
                SeguroSegurado = new SeguroSegurado
                {
                    Residencia = new Residencia
                    {
                        Rua = "",
                        Bairro = "",
                        Cidade = ""
                    }
                }
            };

            var servicoValidacao = new ServicoValidacaoSegurosResidenciais();
            var resultado = servicoValidacao.Validar(seguro);

            Assert.IsFalse(resultado.Valido);
        }
    }
}