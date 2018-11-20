using Seguradora.Dominio.Models.Segurados;

namespace Seguradora.Dominio.Models.Seguros
{
    /// <summary>
    /// Representa um seguro.
    /// </summary>
    public class Seguro
    {
        public int Id { get; set; }
        public string CpfCnpj { get; set; }
        public ETipoSeguro Tipo { get; set; }

        public int SeguroSeguradoId { get; set; }
        public SeguroSegurado SeguroSegurado { get; set; }
    }
}