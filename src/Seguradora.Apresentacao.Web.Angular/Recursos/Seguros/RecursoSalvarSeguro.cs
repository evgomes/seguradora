using System.ComponentModel.DataAnnotations;

namespace Seguradora.Apresentacao.Web.Angular.Recursos.Seguros
{
    public class RecursoSalvarSeguro
    {
        [Required]
        [MaxLength(14)]
        [MinLength(11)]
        public string CpfCnpj { get; set; }

        [Required]
        [Range(0, 3)]
        public byte CodigoTipo { get; set; }

        [StringLength(11)]
        public string CpfSegurado { get; set; }

        [MaxLength(100)]
        public string Rua { get; set; }
        public short? Numero { get; set; }

        [MaxLength(100)]
        public string Bairro { get; set; }

        [MaxLength(100)]
        public string Cidade { get; set; }

        [StringLength(7)]
        public string Placa { get; set; }
    }
}