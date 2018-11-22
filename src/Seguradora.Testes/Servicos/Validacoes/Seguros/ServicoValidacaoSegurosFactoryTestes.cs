using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Servicos.Validacoes.Seguros;

namespace Seguradora.Testes.Servicos.Validacoes.Seguros
{
    [TestClass]
    public class ServicoValidacaoSegurosFactoryTestes
    {
        [TestMethod]
        public void Deve_Retornar_Servico_Validacao_Residencial_Para_Tipo_Seguro_Residencial()
        {
            var seguro = ServicoValidacaoSegurosFactory.GetServicoPara(ETipoSeguro.Residencial);

            Assert.IsNotNull(seguro);
            Assert.IsInstanceOfType(seguro, typeof(ServicoValidacaoSegurosResidenciais));
        }

        [TestMethod]
        public void Deve_Retornar_Servico_Validacao_Veiculo_Para_Tipo_Seguro_Veiculo()
        {
            var seguro = ServicoValidacaoSegurosFactory.GetServicoPara(ETipoSeguro.Automovel);

            Assert.IsNotNull(seguro);
            Assert.IsInstanceOfType(seguro, typeof(ServicoValidacaoSegurosVeiculos));
        }

        [TestMethod]
        public void Deve_Retornar_Servico_Validacao_Vida_Para_Tipo_Seguro_De_Vida()
        {
            var seguro = ServicoValidacaoSegurosFactory.GetServicoPara(ETipoSeguro.Vida);

            Assert.IsNotNull(seguro);
            Assert.IsInstanceOfType(seguro, typeof(ServicoValidacaoSegurosVida));
        }
    }
}