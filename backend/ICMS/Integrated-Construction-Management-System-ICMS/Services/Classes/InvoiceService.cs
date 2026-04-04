using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

public class InvoiceService(AppDbContext dbContext) : IInvoiceService
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<InvoiceResponse> AddNew(InvoiceRequest request, CancellationToken cancellationToken = default)
    {
        var invoice = request.Adapt<Invoice>();

        await _dbContext.Invoice.AddAsync(invoice, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return invoice.Adapt<InvoiceResponse>();
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var invoice = await _dbContext.Invoice.FindAsync(new object[] { id }, cancellationToken);

        if (invoice is null)
            return false;

        _dbContext.Invoice.Remove(invoice);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<IEnumerable<InvoiceResponse?>> GetAll(CancellationToken cancellationToken = default)
    {
        var invoices = await _dbContext.Invoice
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return invoices.Adapt<IEnumerable<InvoiceResponse>>();
    }

    public async Task<InvoiceResponse?> GetById(int id, CancellationToken cancellationToken = default)
    {
        var invoice = await _dbContext.Invoice
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (invoice is null)
            return null;

        return invoice.Adapt<InvoiceResponse>();
    }

    public async Task<bool> Update(int id, InvoiceRequest request, CancellationToken cancellationToken = default)
    {
        var invoice = await _dbContext.Invoice.FindAsync(new object[] { id }, cancellationToken);

        if (invoice is null)
            return false;

        request.Adapt(invoice);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}