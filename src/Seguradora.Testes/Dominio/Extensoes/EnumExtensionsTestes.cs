using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seguradora.Dominio.Extensoes;

namespace Seguradora.Testes.Dominio.Extensoes
{
    public class EnumExtensionsTestes
    {
        enum Teste
        {
            [System.ComponentModel.Description("Valor A")]
            A,
            B
        }

        [TestMethod]
        public void Deve_Retornar_Descricao_Enum()
        {
            var descricao = Teste.A.GetDescricao();

            Assert.AreEqual("Valor A", descricao);
        }

        [TestMethod]
        public void Deve_Retornar_Enum_Como_String_Quando_Nao_Houver_Atributo_Descricao()
        {
            var descricao = Teste.B.GetDescricao();

            Assert.AreEqual("B", descricao);
        }
    }
}