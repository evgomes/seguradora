using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Dominio.Sevicos.Seguros
{
    public class RequisicaoListagemSeguros
    {
        public ETipoSeguro? TipoSeguro { get; set; }
        
        public RequisicaoListagemSeguros(ETipoSeguro? tipoSeguro)
        {
            this.TipoSeguro = tipoSeguro;
        }
    }
}