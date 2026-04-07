using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

public class InvoiceService(AppDbContext dbContext) : IInvoiceService
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<InvoiceResponse> AddNew(InvoiceRequest request, CancellationToken cancellationToken = default)
    {
        var New = request.Adapt<Invoice>();
        await _dbContext.AddAsync(New);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return New.Adapt<InvoiceResponse>();
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var invoice = GetId(id).Adapt<Invoice>();
        if (invoice is null) { return false; }
        _dbContext.Invoice.Remove(invoice);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task<IEnumerable<InvoiceResponse?>> GetAll(CancellationToken cancellationToken = default)
    {
        var AllResponce = await _dbContext.Invoice.AsNoTracking().ToListAsync(cancellationToken);
        return AllResponce.Adapt<IEnumerable<InvoiceResponse>>();
    }

    public async Task<InvoiceResponse?> GetId(int id, CancellationToken cancellationToken = default)
    {
        var One = await _dbContext.Invoice.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return One.Adapt<InvoiceResponse>();
    }

    public async Task<bool> Update(int id, InvoiceRequest request, CancellationToken cancellationToken = default)
    {
        var invoicerequest = request.Adapt<Invoice>();
        var invoice = GetId(id).Adapt<Invoice>();
        if (invoicerequest is null) { return false; }
        invoicerequest.ProjectId = invoice.ProjectId;
        invoicerequest.Title = invoice.Title;
        invoicerequest.Type = invoice.Type;
        invoicerequest.Status = invoice.Status;
        invoicerequest.File = invoice.File;
        invoicerequest.PeriodFrom = invoice.PeriodFrom;
        invoicerequest.PeriodTo = invoice.PeriodTo;
        invoicerequest.InvoiceDate = invoice.InvoiceDate;
        invoicerequest.TotalAmount = invoice.TotalAmount;
        invoicerequest.ApplicationUserId = invoice.ApplicationUserId;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}