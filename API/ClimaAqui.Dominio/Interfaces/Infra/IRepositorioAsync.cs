﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClimaAqui.Dominio.Entidades;

namespace ClimaAqui.Dominio.Interfaces.Infra
{
    public interface IRepositorioAsync<TEntity> where TEntity : class, EntidadeBase
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> AddAsync(TEntity obj);
        Task<int> AddRangeAsync(IEnumerable<TEntity> entidades);

        Task<TEntity> BuscarPorIdAsync(object id);
        Task<IEnumerable<TEntity>> BuscarAsync();

        Task<int> UpdateAsync(TEntity obj);
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entidades);

        Task<bool> DeleteAsync(object id);
        Task<int> DeleteAsync(TEntity obj);
        Task<int> DeleteRangeAsync(IEnumerable<TEntity> entidades);
    }
}