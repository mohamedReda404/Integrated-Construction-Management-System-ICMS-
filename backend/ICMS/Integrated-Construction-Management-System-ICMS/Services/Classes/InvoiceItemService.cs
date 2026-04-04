using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

public class InvoiceItemService(AppDbContext dbContext) : IInvoiceItemService
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<InvoiceItemResponse> AddNew(InvoiceItemRequest request, CancellationToken cancellationToken = default)
    {
        var item = request.Adapt<InvoiceItem>();

        await _dbContext.InvoiceItem.AddAsync(item, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return item.Adapt<InvoiceItemResponse>();
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var item = await _dbContext.InvoiceItem.FindAsync(new object[] { id }, cancellationToken);

        if (item is null)
            return false;

        _dbContext.InvoiceItem.Remove(item);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<IEnumerable<InvoiceItemResponse?>> GetAll(CancellationToken cancellationToken = default)
    {
        var items = await _dbContext.InvoiceItem
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return items.Adapt<IEnumerable<InvoiceItemResponse>>();
    }

    public async Task<InvoiceItemResponse?> GetById(int id, CancellationToken cancellationToken = default)
    {
        var item = await _dbContext.InvoiceItem
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (item is null)
            return null;

        return item.Adapt<InvoiceItemResponse>();
    }

    public async Task<bool> Update(int id, InvoiceItemRequest request, CancellationToken cancellationToken = default)
    {
        var item = await _dbContext.InvoiceItem.FindAsync(new object[] { id }, cancellationToken);

        if (item is null)
            return false;

        request.Adapt(item);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}