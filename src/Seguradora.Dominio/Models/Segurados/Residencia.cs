using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Dominio.Models.Segurados
{
    /// <summary>
    /// Objeto segurado do tipo "residência". Contém informações do endereço de risco.
    /// </summary>
    public class Residencia : Segurado
    {
        public string Rua { get; set; }
        public short? Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public SeguroSegurado SeguroSegurado { get; set; }
    }
}