using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seguradora.Dominio.Models.Seguros;
using Seguradora.Dominio.Repositorios.Seguros;
using Seguradora.Persistencia.EF.Contextos;

namespace Seguradora.Persistencia.EF.Repositorios.Seguros
{
    public class RepositorioSeguros : IRepositorioSeguros
    {
        private readonly SeguradoraDbContext _contexto;

        public RepositorioSeguros(SeguradoraDbContext contexto)
        {
            _contexto = contexto;

        }
        public async Task<IEnumerable<Seguro>> ListarAsync(ETipoSeguro? tipo)
        {
            if (tipo == null)
                return await ListarSemRelacionamentosAsync();

            switch (tipo.Value)
            {
                case ETipoSeguro.Automovel:
                    return await ListarSegurosVeiculosAsync();
                case ETipoSeguro.Residencial:
                    return await ListarSegurosResidenciais();
                case ETipoSeguro.Vida:
                default:
                    return await ListarSegurosDeVidaAsync();

            }
        }

        public async Task<Seguro> GetAsync(int id)
        {
            return await _contexto.Seguros.Include(s => s.SeguroSegurado).ThenInclude(ss => ss.Residencia)
                                          .Include(s => s.SeguroSegurado).ThenInclude(ss => ss.Vida)
                                          .Include(s => s.SeguroSegurado).ThenInclude(ss => ss.Veiculo)
                                          .SingleOrDefaultAsync(s => s.Id == id);
                                          
        }

        public async Task AdicionarAsync(Seguro seguro)
        {
            await _contexto.Seguros.AddAsync(seguro);
        }

        public void Atualizar(Seguro seguro)
        {
            _contexto.Seguros.Update(seguro);
        }

        public void Excluir(Seguro seguro)
        {
            _contexto.Seguros.Remove(seguro);
        }

        private async Task<IEnumerable<Seguro>> ListarSemRelacionamentosAsync()
        {
            return await _contexto.Seguros.OrderByDescending(s => s.Id)
                                          .AsNoTracking()
                                          .ToListAsync();
        }

        private async Task<IEnumerable<Seguro>> ListarSegurosDeVidaAsync()
        {
            return await _contexto.Seguros.Include(s => s.SeguroSegurado)
                .ThenInclude(ss => ss.Vida)
                .Where(s => s.Tipo == ETipoSeguro.Vida)
                .OrderByDescending(s => s.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        private async Task<IEnumerable<Seguro>> ListarSegurosResidenciais()
        {
            return await _contexto.Seguros.Include(s => s.SeguroSegurado)
                .ThenInclude(ss => ss.Residencia)
                .Where(s => s.Tipo == ETipoSeguro.Residencial)
                .OrderByDescending(s => s.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        private async Task<IEnumerable<Seguro>> ListarSegurosVeiculosAsync()
        {
            return await _contexto.Seguros.Include(s => s.SeguroSegurado)
                .ThenInclude(ss => ss.Veiculo)
                .Where(s => s.Tipo == ETipoSeguro.Automovel)
                .OrderByDescending(s => s.Id)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}