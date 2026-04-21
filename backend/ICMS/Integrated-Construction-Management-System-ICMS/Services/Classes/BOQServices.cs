namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class BOQServices(AppDbContext dbContext) : IBOQServices
    {
        private readonly AppDbContext _dbContext=dbContext;
        public async Task<BOQResponce> AddNew(BOQRequest request, CancellationToken cancellationToken = default)
        {
            var NewBOQ = request.Adapt<BOQ>();
            await _dbContext.AddAsync(NewBOQ);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return NewBOQ.Adapt<BOQResponce>();
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var boq = GetId(id).Adapt<BOQ>();
            if (boq is null) { return false; }
            _dbContext.BOQ.Remove(boq);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ExistsByNameAsync(string Title)
        {
            return await _dbContext.BOQ.AnyAsync(x => x.Title == Title);
        }

        public async Task<IEnumerable<BOQResponce?>> GetAll(CancellationToken cancellationToken = default)
        {
            var AllBOQResponce = await _dbContext.BOQ.AsNoTracking().ToListAsync(cancellationToken);
            return AllBOQResponce.Adapt<IEnumerable<BOQResponce>>();
        }

        public async Task<BOQResponce?> GetId(int id, CancellationToken cancellationToken = default)
        {
            var Oneproject = await _dbContext.BOQ.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return Oneproject.Adapt<BOQResponce>();
        }

        public async Task<bool> Update(int id, BOQRequest request, CancellationToken cancellationToken = default)
        {
            var requestBOQ = request.Adapt<BOQ>();
            var boq = GetId(id).Adapt<BOQ>();
            if (boq is null) { return false; }
            boq.Title = requestBOQ.Title; 
            boq.Description = requestBOQ.Description; 
            boq.Condetion = requestBOQ.Condetion; 
            boq.Unit = requestBOQ.Unit; 
            boq.Section = requestBOQ.Section; 
            boq.Quantity = requestBOQ.Quantity; 
            boq.Type = requestBOQ.Type; 
            boq.Date = requestBOQ.Date; 
            boq.File = requestBOQ.File; 

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
