using Seguradora.Dominio.Models.Segurados;

namespace Seguradora.Dominio.Models.Seguros
{
    public class SeguroSegurado
    {
        public int Id { get; set; }
        
        public int SeguroId { get; set; }
        public Seguro Seguro { get; set; }

        public int? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public int? VidaId { get; set; }
        public Vida Vida { get; set; }

        public int? ResidenciaId { get; set; }
        public Residencia Residencia { get; set; }
    }
}