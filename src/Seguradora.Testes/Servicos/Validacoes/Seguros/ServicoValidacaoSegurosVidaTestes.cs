using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seguradora.Dominio.Models.Segurados;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Servicos.Validacoes.Seguros;

namespace Seguradora.Testes.Servicos.Validacoes.Seguros
{
    [TestClass]
    public class ServicoValidacaoSegurosVidaTestes
    {
        [TestMethod]
        public void Deve_Retornar_Valido_Para_Seguro_Vida_Valido()
        {
            var seguro = new Seguro
            {
                CpfCnpj = "11122233344",
                Tipo = ETipoSeguro.Residencial,
                SeguroSegurado = new SeguroSegurado
                {
                   Vida = new Vida
                   {
                       Cpf = "11122233344"
                   }
                }
            };

            var servicoValidacao = new ServicoValidacaoSegurosVida();
            var resultado = servicoValidacao.Validar(seguro);

            Assert.IsTrue(resultado.Valido);
        }

        [TestMethod]
        public void Deve_Retornar_Invalido_Para_Seguro_Vida_Invalido()
        {
            var seguro = new Seguro
            {
                CpfCnpj = "11122233344",
                Tipo = ETipoSeguro.Residencial,
                SeguroSegurado = new SeguroSegurado
                {
                    Vida = new Vida
                    {
                        Cpf = "111111111111111111111111111"
                    }
                }
            };

            var servicoValidacao = new ServicoValidacaoSegurosVida();
            var resultado = servicoValidacao.Validar(seguro);

            Assert.IsFalse(resultado.Valido);
        }
    }
}