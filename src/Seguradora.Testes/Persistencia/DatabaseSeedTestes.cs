using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seguradora.Persistencia.EF;
using Seguradora.Persistencia.EF.Contextos;

namespace Seguradora.Testes.Persistencia
{
    [TestClass]
    public class DatabaseSeedTestes
    {
        [TestMethod]
        public void Deve_Criar_Registros_Base()
        {
            var opcoes = new DbContextOptionsBuilder<SeguradoraDbContext>().UseInMemoryDatabase("teste").Options;
            var contexto = new SeguradoraDbContext(opcoes);

            DatabaseSeed.Seed(contexto);

            Assert.IsTrue(contexto.Seguros.Count() > 0);
        }
    }
}