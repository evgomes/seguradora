using System.Collections.Generic;
using System.Linq;
using Seguradora.Dominio.Models.Segurados;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Persistencia.EF.Contextos;

namespace Seguradora.Persistencia.EF
{
    /// <summary>
    /// O EF Core suporta seed de dados através do método "OnModelCreating", porém prefiro manter essa 
    /// funcionalidade separada para permitir utilizar injeção de dependência de serviços nessa classe 
    /// caso necessário.
    /// 
    /// Exemplo de API onde utilizei essa funcionalidade: https://github.com/evgomes/jwt-api/blob/master/src/Persistence/DatabaseSeed.cs
    /// </summary>
    public static class DatabaseSeed
    {
        public static void Seed(SeguradoraDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Seguros.Count() == 0)
            {
                var seguros = new List<Seguro>
                {
                    new Seguro
                    {
                        CpfCnpj = "12345678911",
                        Tipo = ETipoSeguro.Automovel,
                        SeguroSegurado = new SeguroSegurado
                        {
                            Veiculo = new Veiculo
                            {
                                Placa = "AVW2192"
                            }
                        }
                    },

                    new Seguro
                    {
                        CpfCnpj = "11122233344",
                        Tipo = ETipoSeguro.Residencial,
                        SeguroSegurado = new SeguroSegurado
                        {
                            Residencia = new Residencia
                            {
                                Rua = "Rua Teste",
                                Numero = 200,
                                Bairro = "Bairro Teste",
                                Cidade = "Curitiba"
                            }
                        }
                    },

                    new Seguro
                    {
                        CpfCnpj = "22233355544477",
                        Tipo = ETipoSeguro.Vida,
                        SeguroSegurado = new SeguroSegurado
                        {
                            Vida = new Vida
                            {
                                Cpf = "11122266688"
                            }
                        }
                    },
                };

                foreach(var seguro in seguros)
                {
                    context.Seguros.Add(seguro);
                    context.SaveChanges();
                }
            }
        }
    }
}