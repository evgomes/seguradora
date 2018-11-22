using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seguradora.Apresentacao.Web.Angular.Mapeamentos;
using Seguradora.Apresentacao.Web.Angular.Recursos.Base;
using Seguradora.Apresentacao.Web.Angular.Recursos.Seguros;
using Seguradora.Dominio.Models.Segurados;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos.Seguros;

namespace Seguradora.Testes.Apresentacao.Mapeamentos
{
    [TestClass]
    public class ProfilesTestes
    {
        [TestInitialize]
        public void ConfigurarAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ModelParaRecursoProfile());
                cfg.AddProfile(new RespostaParaRecursoProfile());
                cfg.AddProfile(new RecursoParaModelProfile());
            });
        }

        [TestCleanup]
        public void ResetarPerfil()
        {
            Mapper.Reset();
        }

        [TestMethod]
        public void Deve_Configurar_Corretamente_Perfis_De_Mapeamento()
        {
            Mapper.Configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void Deve_Mapear_Seguro_Para_Recurso_Seguro()
        {
            var seguro = new Seguro
            {
                Id = 1,
                CpfCnpj = "12345678912",
                Tipo = ETipoSeguro.Residencial,
            };

            var resultado = Mapper.Map<Seguro, RecursoSeguro>(seguro);

            Assert.IsInstanceOfType(resultado, typeof(RecursoSeguro));
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void Deve_Mapear_Segurado_Residencial_Para_Recurso_Segurado_Residencial()
        {
            var seguro = new Seguro
            {
                Id = 1,
                CpfCnpj = "12345678912",
                Tipo = ETipoSeguro.Residencial,
                SeguroSegurado = new SeguroSegurado
                {
                Residencia = new Residencia
                {
                Rua = "Teste",
                Numero = 1,
                Bairro = "Teste",
                Cidade = "Teste"
                }
                }
            };

            var resultado = Mapper.Map<Seguro, RecursoSeguradoResidencia>(seguro);

            Assert.IsInstanceOfType(resultado, typeof(RecursoSeguradoResidencia));
            Assert.IsNotNull(resultado);
            Assert.AreEqual("Teste", resultado.Rua);
        }

        [TestMethod]
        public void Deve_Mapear_Segurado_Veicular_Para_Recurso_Segurado_Veiculo()
        {
            var seguro = new Seguro
            {
                Id = 1,
                CpfCnpj = "12345678912",
                Tipo = ETipoSeguro.Automovel,
                SeguroSegurado = new SeguroSegurado
                {
                    Veiculo = new Veiculo
                    {
                        Placa = "AAA1111"
                    }
                }
            };

            var resultado = Mapper.Map<Seguro, RecursoSeguradoVeiculo>(seguro);

            Assert.IsInstanceOfType(resultado, typeof(RecursoSeguradoVeiculo));
            Assert.IsNotNull(resultado);
            Assert.AreEqual("AAA1111", resultado.Placa);
        }

        [TestMethod]
        public void Deve_Mapear_Segurado_Vida_Para_Recurso_Segurado_Vida()
        {
            var seguro = new Seguro
            {
                Id = 1,
                CpfCnpj = "12345678912",
                Tipo = ETipoSeguro.Vida,
                SeguroSegurado = new SeguroSegurado
                {
                Vida = new Vida
                {
                Cpf = "11122233344"
                }
                }
            };

            var resultado = Mapper.Map<Seguro, RecursoSeguradoVida>(seguro);

            Assert.IsInstanceOfType(resultado, typeof(RecursoSeguradoVida));
            Assert.IsNotNull(resultado);
            Assert.AreEqual("11122233344", resultado.CpfSegurado);
        }

        [TestMethod]
        public void Deve_Mapear_Resposta_Seguros_Para_Resposta_Json_Generica_Seguros()
        {
            var resposta = SegurosResposta.CriarSucesso(new List<Seguro> { new Seguro() });
            var json = Mapper.Map<SegurosResposta, RespostaJsonGenerica<IEnumerable<RecursoSeguro>>>(resposta);

            Assert.IsInstanceOfType(json, typeof(RespostaJsonGenerica<IEnumerable<RecursoSeguro>>));
            Assert.IsTrue(json.Sucesso);
        }

        [TestMethod]
        public void Deve_Mapear_Resposta_Gravar_Seguro_Para_Resposta_Json_Generica_Seguro()
        {
            var resposta = GravarSeguroResposta.CriarSucesso(new Seguro());
            var json = Mapper.Map<GravarSeguroResposta, RespostaJsonGenerica<RecursoSeguro>>(resposta);

            Assert.IsInstanceOfType(json, typeof(RespostaJsonGenerica<RecursoSeguro>));
            Assert.IsTrue(json.Sucesso);
        }

        [TestMethod]
        public void Deve_Mapear_Recurso_Salvar_Seguro_Veicular_Para_Model_Respectiva()
        {
            var recurso = new RecursoSalvarSeguro
            {
                CpfCnpj = "11122233344",
                CodigoTipo = (int) ETipoSeguro.Automovel,
                Placa = "AAA1111"
            };

            var resultado = Mapper.Map<RecursoSalvarSeguro, Seguro>(recurso);

            Assert.IsNotNull(resultado.SeguroSegurado.Veiculo);
            Assert.IsNull(resultado.SeguroSegurado.Vida);
            Assert.IsNull(resultado.SeguroSegurado.Residencia);
            Assert.AreEqual("11122233344", resultado.CpfCnpj);
            Assert.AreEqual(ETipoSeguro.Automovel, resultado.Tipo);
            Assert.AreEqual("AAA1111", resultado.SeguroSegurado.Veiculo.Placa);
        }

        [TestMethod]
        public void Deve_Mapear_Recurso_Salvar_Seguro_Residencial_Para_Model_Respectiva()
        {
            var recurso = new RecursoSalvarSeguro
            {
                CpfCnpj = "11122233344",
                CodigoTipo = (int) ETipoSeguro.Residencial,
                Rua = "Rua Teste",
                Numero = 1,
                Bairro = "Bairro Teste",
                Cidade = "Cidade Teste"
            };

            var resultado = Mapper.Map<RecursoSalvarSeguro, Seguro>(recurso);

            Assert.IsNotNull(resultado.SeguroSegurado.Residencia);
            Assert.IsNull(resultado.SeguroSegurado.Vida);
            Assert.IsNull(resultado.SeguroSegurado.Veiculo);
            Assert.AreEqual("11122233344", resultado.CpfCnpj);
            Assert.AreEqual(ETipoSeguro.Residencial, resultado.Tipo);
            Assert.AreEqual("Rua Teste", resultado.SeguroSegurado.Residencia.Rua);
            Assert.AreEqual((short) 1, resultado.SeguroSegurado.Residencia.Numero);
            Assert.AreEqual("Bairro Teste", resultado.SeguroSegurado.Residencia.Bairro);
            Assert.AreEqual("Cidade Teste", resultado.SeguroSegurado.Residencia.Cidade);
        }

        [TestMethod]
        public void Deve_Mapear_Recurso_Salvar_Seguro_Vida_Para_Model_Respectiva()
        {
            var recurso = new RecursoSalvarSeguro
            {
                CpfCnpj = "11122233344",
                CodigoTipo = (int) ETipoSeguro.Vida,
                CpfSegurado = "11122233344"
            };

            var resultado = Mapper.Map<RecursoSalvarSeguro, Seguro>(recurso);

            Assert.IsNotNull(resultado.SeguroSegurado.Vida);
            Assert.IsNull(resultado.SeguroSegurado.Veiculo);
            Assert.IsNull(resultado.SeguroSegurado.Residencia);
            Assert.AreEqual("11122233344", resultado.CpfCnpj);
            Assert.AreEqual(ETipoSeguro.Vida, resultado.Tipo);
            Assert.AreEqual("11122233344", resultado.SeguroSegurado.Vida.Cpf);
        }
    }
}