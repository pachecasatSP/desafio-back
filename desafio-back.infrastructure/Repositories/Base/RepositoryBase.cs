namespace desafio_back.infrastructure.Repositories.Base;

using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Models.Base;
using desafio_back.infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

public abstract class RepositoryBase<TEntity>: IRepository<TEntity> where TEntity : EntityBase, new()
{
    private readonly RentalManagementContext _context;
    
    protected RepositoryBase(RentalManagementContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {        
        var dbSet = _context.Set<TEntity>();

        dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        using var ctx = _context;
        var dbSet = ctx.Set<TEntity>();

        dbSet.Update(entity);
       
        await ctx.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int internalId)
    {
        using var ctx = _context;
        var dbSet = ctx.Set<TEntity>();

        var entity = await dbSet.FindAsync(internalId);
        if (entity == null)
            return false;

        dbSet.Remove(entity);
        await ctx.SaveChangesAsync();
        return true;
    }

    public async Task<TEntity> GetAsync(string identificador)
    {
        using var ctx = _context;
        var dbSet = ctx.Set<TEntity>();

        return await dbSet.FindAsync(identificador);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {        
        var dbSet = _context.Set<TEntity>();
        return await dbSet.ToListAsync();
    }
    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var dbSet = _context.Set<TEntity>();
        return await dbSet.FirstOrDefaultAsync(predicate);
    }
}
