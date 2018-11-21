using System.ComponentModel;

namespace Seguradora.Dominio.Models.Seguros
{
    public enum ETipoSeguro : byte
    {
        [Description("Automóvel")]
        Automovel = 1,

        [Description("Residencial")]
        Residencial = 2,

        [Description("Seguro de Vida")]
        Vida = 3
    }
}