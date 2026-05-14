using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

public class InvoiceItemService(AppDbContext dbContext) : IInvoiceItemService
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<InvoiceItemResponse> AddNew(InvoiceItemRequest request, CancellationToken cancellationToken = default)
    {
        var New = request.Adapt<InvoiceItem>();
        await _dbContext.AddAsync(New);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return New.Adapt<InvoiceItemResponse>();
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var invoiceItem = await _dbContext.InvoiceItem.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (invoiceItem is null) { return false; }
        _dbContext.InvoiceItem.Remove(invoiceItem);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task<IEnumerable<InvoiceItemResponse?>> GetAll(CancellationToken cancellationToken = default)
    {
        var AllResponce = await _dbContext.InvoiceItem.AsNoTracking().ToListAsync(cancellationToken);
        return AllResponce.Adapt<IEnumerable<InvoiceItemResponse>>();
    }

    public async Task<InvoiceItemResponse?> GetId(int id, CancellationToken cancellationToken = default)
    {
        var One = await _dbContext.InvoiceItem.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return One.Adapt<InvoiceItemResponse>();
    }

    public async Task<bool> Update(int id, InvoiceItemRequest request, CancellationToken cancellationToken = default)
    {
        var invoiceItemrequest = request.Adapt<InvoiceItem>();
        var invoiceitem = await _dbContext.InvoiceItem.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (invoiceitem is null) { return false; }
        invoiceitem.InvoiceId = invoiceItemrequest.InvoiceId;
        invoiceitem.Previous_qty = invoiceItemrequest.Previous_qty;
        invoiceitem.Current_qty = invoiceItemrequest.Current_qty;
        invoiceitem.Total_qty = invoiceItemrequest.Total_qty;
        invoiceitem.Rate = invoiceItemrequest.Rate;
        invoiceitem.Amount = invoiceItemrequest.Amount;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}