namespace BuildingBlocks.Infrastructure.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<TEntity> GetByNumberAsync(string number, CancellationToken ct = default);
    Task<List<TEntity>> GetPagedAsync(int pageIndex = 1, int pageSize = 10, CancellationToken ct = default);
    Task AddAsync(TEntity entity, CancellationToken ct = default);
    Task UpdateAsync(TEntity entity, CancellationToken ct = default);
    Task DeleteAsync(TEntity entity, CancellationToken ct = default);
}