using System.Collections.Generic;
using AutoMapper;
using Seguradora.Apresentacao.Web.Angular.Recursos;
using Seguradora.Apresentacao.Web.Angular.Recursos.Base;
using Seguradora.Apresentacao.Web.Angular.Recursos.Seguros;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Sevicos.Seguros;

namespace Seguradora.Apresentacao.Web.Angular.Mapeamentos
{
    /// <summary>
    /// Mapeamentos de resposta a requisições de serviços para recursos de API.
    /// </summary>
    public class RespostaParaRecursoProfile : Profile
    {
        public RespostaParaRecursoProfile()
        {
            CreateMap<SegurosResposta, RespostaJsonGenerica<IEnumerable<RecursoSeguro>>>()
                .ForMember(src => src.Sucesso, opt => opt.MapFrom(src => src.Successo))
                .ForMember(src => src.Mensagem, opt => opt.MapFrom(src => src.Mensagem))
                .ForMember(src => src.Dados, opt => opt.MapFrom(src => src.Seguros));

            CreateMap<SegurosResposta, RespostaJsonGenerica<IEnumerable<RecursoSeguradoResidencia>>>()
                .ForMember(src => src.Sucesso, opt => opt.MapFrom(src => src.Successo))
                .ForMember(src => src.Mensagem, opt => opt.MapFrom(src => src.Mensagem))
                .ForMember(src => src.Dados, opt => opt.MapFrom(src => src.Seguros));

            CreateMap<SegurosResposta, RespostaJsonGenerica<IEnumerable<RecursoSeguradoVeiculo>>>()
                .ForMember(src => src.Sucesso, opt => opt.MapFrom(src => src.Successo))
                .ForMember(src => src.Mensagem, opt => opt.MapFrom(src => src.Mensagem))
                .ForMember(src => src.Dados, opt => opt.MapFrom(src => src.Seguros));

            CreateMap<SegurosResposta, RespostaJsonGenerica<IEnumerable<RecursoSeguradoVida>>>()
                .ForMember(src => src.Sucesso, opt => opt.MapFrom(src => src.Successo))
                .ForMember(src => src.Mensagem, opt => opt.MapFrom(src => src.Mensagem))
                .ForMember(src => src.Dados, opt => opt.MapFrom(src => src.Seguros));


            CreateMap<TiposSeguroResposta, RespostaJsonGenerica<IEnumerable<RecursoTipoSeguro>>>()
                .ForMember(src => src.Sucesso, opt => opt.MapFrom(src => src.Successo))
                .ForMember(src => src.Mensagem, opt => opt.MapFrom(src => src.Mensagem))
                .ForMember(src => src.Dados, opt => opt.MapFrom(src => src.TiposSeguros));
        }
    }
}