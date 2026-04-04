using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

public class DrawingService(AppDbContext dbContext) : IDrawingService
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<DrawingResponse> AddNew(DrawingRequest request, CancellationToken cancellationToken = default)
    {
        var drawing = request.Adapt<Drawing>();

        await _dbContext.Drawing.AddAsync(drawing, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return drawing.Adapt<DrawingResponse>();
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var drawing = await _dbContext.Drawing.FindAsync(new object[] { id }, cancellationToken);

        if (drawing is null)
            return false;

        _dbContext.Drawing.Remove(drawing);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<IEnumerable<DrawingResponse?>> GetAll(CancellationToken cancellationToken = default)
    {
        var drawings = await _dbContext.Drawing
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return drawings.Adapt<IEnumerable<DrawingResponse>>();
    }

    public async Task<DrawingResponse?> GetById(int id, CancellationToken cancellationToken = default)
    {
        var drawing = await _dbContext.Drawing
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (drawing is null)
            return null;

        return drawing.Adapt<DrawingResponse>();
    }

    public async Task<bool> Update(int id, DrawingRequest request, CancellationToken cancellationToken = default)
    {
        var drawing = await _dbContext.Drawing.FindAsync(new object[] { id }, cancellationToken);

        if (drawing is null)
            return false;

        request.Adapt(drawing);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}