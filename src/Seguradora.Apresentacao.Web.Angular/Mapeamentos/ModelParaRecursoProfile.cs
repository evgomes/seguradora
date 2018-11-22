using AutoMapper;
using Seguradora.Apresentacao.Web.Angular.Recursos.Base;
using Seguradora.Apresentacao.Web.Angular.Recursos.Seguros;
using Seguradora.Dominio.Extensoes;
using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Apresentacao.Web.Angular.Mapeamentos
{
    /// <summary>
    /// Define os mapeamentos de models de domínio para recursos da API.
    /// </summary>
    public class ModelParaRecursoProfile : Profile
    {
        public ModelParaRecursoProfile()
        {
            CreateMap<Seguro, RecursoSeguro>()
                .ForMember(src => src.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(src => src.CpfCnpj, opt => opt.MapFrom(src => src.CpfCnpj))
                .ForMember(src => src.Tipo, opt => opt.MapFrom(src => src.Tipo.GetDescricao()))
                .ForMember(src => src.CodigoTipo, opt => opt.MapFrom(src => (byte)src.Tipo));

            CreateMap<Seguro, RecursoSeguradoResidencia>()
                .ForMember(src => src.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(src => src.CpfCnpj, opt => opt.MapFrom(src => src.CpfCnpj))
                .ForMember(src => src.Tipo, opt => opt.MapFrom(src => src.Tipo.GetDescricao()))
                .ForMember(src => src.CodigoTipo, opt => opt.MapFrom(src => (byte)src.Tipo))
                .ForMember(src => src.Rua, opt => opt.MapFrom(src => src.SeguroSegurado.Residencia.Rua))
                .ForMember(src => src.Numero, opt => opt.MapFrom(src => src.SeguroSegurado.Residencia.Numero))
                .ForMember(src => src.Bairro, opt => opt.MapFrom(src => src.SeguroSegurado.Residencia.Bairro))
                .ForMember(src => src.Cidade, opt => opt.MapFrom(src => src.SeguroSegurado.Residencia.Cidade));

            CreateMap<Seguro, RecursoSeguradoVida>()
                .ForMember(src => src.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(src => src.CpfCnpj, opt => opt.MapFrom(src => src.CpfCnpj))
                .ForMember(src => src.Tipo, opt => opt.MapFrom(src => src.Tipo.GetDescricao()))
                .ForMember(src => src.CodigoTipo, opt => opt.MapFrom(src => (byte)src.Tipo))
                .ForMember(src => src.CpfSegurado, opt => opt.MapFrom(src => src.SeguroSegurado.Vida.Cpf));

            CreateMap<Seguro, RecursoSeguradoVeiculo>()
                .ForMember(src => src.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(src => src.CpfCnpj, opt => opt.MapFrom(src => src.CpfCnpj))
                .ForMember(src => src.Tipo, opt => opt.MapFrom(src => src.Tipo.GetDescricao()))
                .ForMember(src => src.CodigoTipo, opt => opt.MapFrom(src => (byte)src.Tipo))
                .ForMember(src => src.Placa, opt => opt.MapFrom(src => src.SeguroSegurado.Veiculo.Placa));

            CreateMap<Seguro, RespostaJsonGenerica<RecursoSeguradoResidencia>>()
                .ForMember(src => src.Sucesso, opt => opt.MapFrom(src => true))
                .ForMember(src => src.Mensagem, opt => opt.MapFrom(src => string.Empty))
                .ForMember(src => src.Dados, opt => opt.MapFrom(src => src));

            CreateMap<Seguro, RespostaJsonGenerica<RecursoSeguradoVida>>()
                .ForMember(src => src.Sucesso, opt => opt.MapFrom(src => true))
                .ForMember(src => src.Mensagem, opt => opt.MapFrom(src => string.Empty))
                .ForMember(src => src.Dados, opt => opt.MapFrom(src => src));

            CreateMap<Seguro, RespostaJsonGenerica<RecursoSeguradoVeiculo>>()
                .ForMember(src => src.Sucesso, opt => opt.MapFrom(src => true))
                .ForMember(src => src.Mensagem, opt => opt.MapFrom(src => string.Empty))
                .ForMember(src => src.Dados, opt => opt.MapFrom(src => src));

            CreateMap<ETipoSeguro, RecursoTipoSeguro>().ConvertUsing(src => new RecursoTipoSeguro
            {
                Codigo = (byte)src,
                    Nome = src.GetDescricao()
            });
        }
    }
}