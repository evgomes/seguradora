using AutoMapper;
using Seguradora.Apresentacao.Web.Angular.Mapeamentos.TypeConverters;
using Seguradora.Apresentacao.Web.Angular.Recursos.Seguros;
using Seguradora.Dominio.Models.Segurados;
using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Apresentacao.Web.Angular.Mapeamentos
{
    public class RecursoParaModelProfile : Profile
    {
        public RecursoParaModelProfile()
        {
            CreateMap<RecursoSalvarSeguro, Seguro>().ConvertUsing<SeguroTypeConverter>();
        }
    }
}