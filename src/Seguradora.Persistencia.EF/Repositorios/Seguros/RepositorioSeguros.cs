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

        private async Task<IEnumerable<Seguro>> ListarSemRelacionamentosAsync()
        {
            return await _contexto.Seguros.ToListAsync();
        }

        private async Task<IEnumerable<Seguro>> ListarSegurosDeVidaAsync()
        {
            return await _contexto.Seguros.Include(s => s.SeguroSegurado)
                .ThenInclude(ss => ss.Vida)
                .Where(s => s.Tipo == ETipoSeguro.Vida)
                .ToListAsync();
        }

        private async Task<IEnumerable<Seguro>> ListarSegurosResidenciais()
        {
            return await _contexto.Seguros.Include(s => s.SeguroSegurado)
                .ThenInclude(ss => ss.Residencia)
                .Where(s => s.Tipo == ETipoSeguro.Residencial)
                .ToListAsync();
        }

        private async Task<IEnumerable<Seguro>> ListarSegurosVeiculosAsync()
        {
            return await _contexto.Seguros.Include(s => s.SeguroSegurado)
                .ThenInclude(ss => ss.Veiculo)
                .Where(s => s.Tipo == ETipoSeguro.Automovel)
                .ToListAsync();
        }
    }
}