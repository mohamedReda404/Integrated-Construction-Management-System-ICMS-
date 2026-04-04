using Integrated_Construction_Management_System_ICMS.Contracts.Responces;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class BOQPricingServices(AppDbContext dbContext) : IBOQPricingServices
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<BOQPricingResponse> AddNew(BOQPricingRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Adapt<BOQPricing>();

            await _dbContext.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Adapt<BOQPricingResponse>();
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<BOQPricing>().FindAsync(id);

            if (entity is null)
                return false;

            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<BOQPricingResponse>> GetAll(CancellationToken cancellationToken = default)
        {
            var list = await _dbContext.Set<BOQPricing>()
            .AsNoTracking()
                .ToListAsync(cancellationToken);
            return list.Adapt<IEnumerable<BOQPricingResponse>>();
        }

        public async Task<BOQPricingResponse?> GetId(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<BOQPricing>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return entity?.Adapt<BOQPricingResponse>();
        }

        public async Task<bool> Update(int id, BOQPricingRequest request, CancellationToken cancellationToken = default)
        {
            var requestBOQPricing = request.Adabt<BOQPricing>();
            var boqPricing = GetId(id).Adabt<BOQPricing>();
            if (boqPricing is null) { return false; }
            entity.BOQId = request.BOQId;
            entity.ApplicationUserId = request.ApplicationUserId;
            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Status = request.Status;
            entity.UnitRate = request.UnitRate;
            entity.TotalPrice = request.TotalPrice;
            entity.Date = request.Date;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;


        }
    }
}