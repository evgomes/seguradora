using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Dominio.Models.Segurados
{
    /// <summary>
    /// Objeto segurado para o tipo "Veículo". Contém os dados da placa do veículo.
    /// </summary>
    public class Veiculo : Segurado
    {
        public string Placa { get; set; }

        public SeguroSegurado SeguroSegurado { get; set; }
    }
}