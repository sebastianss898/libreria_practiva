namespace GestionBibliotecaApi.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using GestionBibliotecaApi.Data;

public class Repository<T> : IRepository<T> where T : class

{
    protected readonly LibreriaContext _db;


    public Repository(LibreriaContext db)
    {
        _db = db;
    }

    public async Task<List<T>> GetAll() =>
    await _db.Set<T>().ToListAsync();

    public async Task<T?> GetById(int id) =>
        await _db.Set<T>().FindAsync(id);

    public async Task Add(T entity)
    {
        _db.Set<T>().Add(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _db.Set<T>().Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task SaveChanges() =>
       await _db.SaveChangesAsync();

    public async Task<List<T>> GetAllWithInclude<TProperty>(
    Expression<Func<T, TProperty>> include)
    {
        return await _db.Set<T>()
        .Include(include)
        .ToListAsync();
    }

    
    public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate) =>
    await _db.Set<T>().FirstOrDefaultAsync(predicate);
    

    
}

