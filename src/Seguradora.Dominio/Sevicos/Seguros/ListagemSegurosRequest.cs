using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Dominio.Sevicos.Seguros
{
    public class ListagemSegurosRequest
    {
        public ETipoSeguro? TipoSeguro { get; set; }
        
        public ListagemSegurosRequest(ETipoSeguro? tipoSeguro)
        {
            this.TipoSeguro = tipoSeguro;
        }
    }
}