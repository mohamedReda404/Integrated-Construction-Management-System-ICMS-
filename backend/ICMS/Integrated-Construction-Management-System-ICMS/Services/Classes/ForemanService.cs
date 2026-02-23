using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Integrated_Construction_Management_System_ICMS.Models;
using Integrated_Construction_Management_System_ICMS.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class ForemanService : IForemanService
    {
        private readonly AppDbContext _dbContext;

        public ForemanService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Foreman> AddNew(Foreman foreman, CancellationToken cancellationToken)
        {
            if (foreman is null)
                throw new ArgumentNullException(nameof(foreman));

            await _dbContext.Foremen.AddAsync(foreman, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return foreman;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var _foreman = await GetId(id, cancellationToken);

            if (_foreman is null)
                return false;

            _dbContext.Foremen.Remove(_foreman);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Foreman>> GetAll(CancellationToken cancellationToken) =>
            await _dbContext.Foremen.ToListAsync(cancellationToken);

        public async Task<Foreman?> GetId(int id, CancellationToken cancellationToken) =>
            await _dbContext.Foremen
                .FirstOrDefaultAsync(f => f.ForemanId == id, cancellationToken);

        public async Task<bool> Update(int id, Foreman foreman, CancellationToken cancellationToken)
        {
            var _foreman = await GetId(id, cancellationToken);

            if (_foreman != null)
            {
                _foreman.Name = foreman.Name;
                _foreman.Phone = foreman.Phone;
                _foreman.Email = foreman.Email;
                _foreman.ProjectManagerId = foreman.ProjectManagerId;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }

            
        }
    }
}