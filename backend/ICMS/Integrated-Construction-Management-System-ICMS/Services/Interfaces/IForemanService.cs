public interface IForemanService
{
    Task<Foreman> AddNew(Foreman foreman, CancellationToken cancellationToken);
    Task<bool> Delete(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Foreman>> GetAll(CancellationToken cancellationToken);
    Task<Foreman?> GetId(int id, CancellationToken cancellationToken);
    Task<bool> Update(int id, Foreman foreman, CancellationToken cancellationToken);
}