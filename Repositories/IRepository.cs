namespace GestionBibliotecaApi.Repositories;

using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
    Task Add(T entity);
    Task Delete(T entity);
    Task SaveChanges();
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
}