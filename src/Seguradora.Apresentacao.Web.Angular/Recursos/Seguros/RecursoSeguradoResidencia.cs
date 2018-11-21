namespace Seguradora.Apresentacao.Web.Angular.Recursos.Seguros
{
    public class RecursoSeguradoResidencia : RecursoSeguro
    {
        public string Rua { get; set; }
        public short? Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}