using Seguradora.Dominio.Models.Seguros;

namespace Seguradora.Dominio.Models.Segurados
{
    /// <summary>
    /// Representa o objeto segurado de um seguro.
    /// </summary>
    public abstract class Segurado
    {
        public int Id { get; set; }
    }
}