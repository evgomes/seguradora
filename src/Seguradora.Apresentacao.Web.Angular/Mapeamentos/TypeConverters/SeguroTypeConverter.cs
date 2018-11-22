using System;
using System.Text.RegularExpressions;
using AutoMapper;
using Seguradora.Apresentacao.Web.Angular.Recursos.Seguros;
using Seguradora.Dominio.Models.Segurados;
using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Apresentacao.Web.Angular.Mapeamentos.TypeConverters
{
    public class SeguroTypeConverter : ITypeConverter<RecursoSalvarSeguro, Seguro>
    {
        public Seguro Convert(RecursoSalvarSeguro source, Seguro destination, ResolutionContext context)
        {
            var seguro = new Seguro
            {
                Id = 0,
                CpfCnpj = Regex.Replace(source.CpfCnpj, @"\D", "", RegexOptions.IgnoreCase),
                Tipo = (ETipoSeguro)source.CodigoTipo,
                SeguroSegurado = new SeguroSegurado()
            };

            PopularSegurado(source, seguro);

            return seguro;
        }

        private static void PopularSegurado(RecursoSalvarSeguro source, Seguro seguro)
        {
            switch (seguro.Tipo)
            {
                case ETipoSeguro.Residencial:
                    seguro.SeguroSegurado.Residencia = new Residencia
                    {
                        Rua = source.Rua,
                        Numero = source.Numero,
                        Bairro = source.Bairro,
                        Cidade = source.Cidade
                    };
                    break;
                case ETipoSeguro.Automovel:
                    seguro.SeguroSegurado.Veiculo = new Veiculo
                    {
                        Placa =  Regex.Replace(source.Placa.ToUpper(), @"[^a-z0-9]", "", RegexOptions.IgnoreCase)
                    };
                    break;
                case ETipoSeguro.Vida:
                    seguro.SeguroSegurado.Vida = new Vida
                    {
                        Cpf = Regex.Replace(source.CpfSegurado, @"\D", "", RegexOptions.IgnoreCase),
                    };
                    break;
                default:
                    throw new NotImplementedException("Tipo de segurado não mapeado.");
            }
        }
    }
}