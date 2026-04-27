using Integrated_Construction_Management_System_ICMS.Contracts.Responces;
using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class BOQPricingServices(AppDbContext dbContext) : IBOQPricingServices
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<BOQPricingReponce> AddNew(BOQPricingRequest request, CancellationToken cancellationToken = default)
        {
            var New = request.Adapt<BOQPricing>();
            await _dbContext.AddAsync(New);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return New.Adapt<BOQPricingReponce>();
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var bOQPricing = GetId(id).Adapt<BOQPricing>();
            if (bOQPricing is null) { return false; }
            _dbContext.BOQPricing.Remove(bOQPricing);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<BOQPricingReponce?>> GetAll(CancellationToken cancellationToken = default)
        {
            var AllResponce = await _dbContext.BOQPricing.AsNoTracking().ToListAsync(cancellationToken);
            return AllResponce.Adapt<IEnumerable<BOQPricingReponce>>();
        }

        public async Task<BOQPricingReponce?> GetId(int id, CancellationToken cancellationToken = default)
        {
            var One = await _dbContext.BOQPricing.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return One.Adapt<BOQPricingReponce>();
        }

        public async Task<bool> Update(int id, BOQPricingRequest request, CancellationToken cancellationToken = default)
        {
            var requestBOQPricing = request.Adapt<BOQPricing>();
            var boqPricing = await _dbContext.BOQPricing.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (boqPricing is null) { return false; }
            requestBOQPricing.BOQId = boqPricing.BOQId;
            requestBOQPricing.Title = boqPricing.Title;
            requestBOQPricing.Description = boqPricing.Description;
            requestBOQPricing.Status = boqPricing.Status;
            requestBOQPricing.UnitRate = boqPricing.UnitRate;
            requestBOQPricing.TotalPrice = boqPricing.TotalPrice;
            requestBOQPricing.Date = boqPricing.Date;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;


        }
    }
}