using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Dominio.Models.Segurados
{
    /// <summary>
    /// Objeto segurado do tipo "Vida". Contém o CPF da pessoa segurada.
    /// </summary>
    public class Vida : Segurado
    {
        public string Cpf { get; set; }

        public SeguroSegurado SeguroSegurado { get; set; }
    }
}