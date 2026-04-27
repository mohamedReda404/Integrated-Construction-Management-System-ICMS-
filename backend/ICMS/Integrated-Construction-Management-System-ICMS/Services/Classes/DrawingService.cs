
using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class DrawingService(AppDbContext dbContext) : IDrawingService
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<DrawingResponse> AddNew(DrawingRequest request, CancellationToken cancellationToken = default)
        {
            var New = request.Adapt<Drawing>();
            await _dbContext.Drawing.AddAsync(New);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return New.Adapt<DrawingResponse>();
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var Drawing = GetId(id).Adapt<Drawing>();
            if (Drawing is null) { return false; }
            _dbContext.Drawing.Remove(Drawing);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
        public async Task<IEnumerable<DrawingResponse?>> GetAll(CancellationToken cancellationToken = default)
        {
            var AllDrawing = await _dbContext.Drawing.AsNoTracking().ToListAsync(cancellationToken);
            return AllDrawing.Adapt<IEnumerable<DrawingResponse>>();
        }

        public async Task<DrawingResponse?> GetId(int id, CancellationToken cancellationToken = default)
        {
            var OneDrawing = await _dbContext.Drawing.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return OneDrawing.Adapt<DrawingResponse>();
        }

        public async Task<bool> Update(int id, DrawingRequest request, CancellationToken cancellationToken = default)
        {
            var requestDrawing = request.Adapt<Drawing>();
            var drawing = await _dbContext.Drawing.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (drawing is null) { return false; }

            drawing.Title = requestDrawing.Title;
            drawing.Description = requestDrawing.Description;
            drawing.Section = requestDrawing.Section;
            drawing.Status = requestDrawing.Status;
            drawing.Type = requestDrawing.Type;
            drawing.Date = requestDrawing.Date;
            drawing.Photo = requestDrawing.Photo;
            drawing.ApplicationUserId = requestDrawing.ApplicationUserId;
            drawing.ProjectId = requestDrawing.ProjectId;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
