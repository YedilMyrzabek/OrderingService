namespace BuildingBlocks.Application.Interfaces;

public interface IGenericService<TCreateDto, TReadDto, TUpdateDto>
{
    Task<TReadDto> CreateAsync(TCreateDto dto, CancellationToken ct = default);
    Task<TReadDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<List<TReadDto>> GetPagedAsync(int pageIndex, int pageSize, CancellationToken ct = default);
    Task<TReadDto?> UpdateAsync(Guid id, TUpdateDto dto, CancellationToken ct = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
}