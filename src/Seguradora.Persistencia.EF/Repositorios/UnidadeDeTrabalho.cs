using System.Threading.Tasks;
using Seguradora.Dominio.Repositorios;
using Seguradora.Persistencia.EF.Contextos;

namespace Seguradora.Persistencia.EF.Repositorios
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        private readonly SeguradoraDbContext _contexto;

        public UnidadeDeTrabalho(SeguradoraDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task CompletarAsync()
        {
            await _contexto.SaveChangesAsync();
        }
    }
}