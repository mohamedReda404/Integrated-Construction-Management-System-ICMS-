using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Integrated_Construction_Management_System_ICMS.Models;
using Integrated_Construction_Management_System_ICMS.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class ProjectContractService : IProjectContractService
    {
        private readonly AppDbContext _dbContext;

        public ProjectContractService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectContract> AddNew(ProjectContract projectContract, CancellationToken cancellationToken)
        {
            if (projectContract is null) throw new ArgumentNullException(nameof(projectContract));

            await _dbContext.ProjectContracts.AddAsync(projectContract, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return projectContract;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var _projectContract = await GetId(id, cancellationToken);

            if (_projectContract is null)
                return false;

            _dbContext.ProjectContracts.Remove(_projectContract);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<ProjectContract>> GetAll(CancellationToken cancellationToken) =>
            await _dbContext.ProjectContracts.ToListAsync(cancellationToken);

        public async Task<ProjectContract?> GetId(int id, CancellationToken cancellationToken) =>
            await _dbContext.ProjectContracts
                .FirstOrDefaultAsync(i => i.ProjectContractId == id, cancellationToken);

        public async Task<bool> Update(int id, ProjectContract projectContract, CancellationToken cancellationToken)
        {
            var _projectContract = await GetId(id, cancellationToken);

            if (_projectContract != null)
            {
                _projectContract.ContractDate = projectContract.ContractDate;
                _projectContract.ContractDetails = projectContract.ContractDetails;
                _projectContract.EndContractIfs = projectContract.EndContractIfs;
                _projectContract.ClientCondition = projectContract.ClientCondition;
                _projectContract.ClientSignature = projectContract.ClientSignature;
                _projectContract.ManagerSignature = projectContract.ManagerSignature;
                _projectContract.ManagerCondition = projectContract.ManagerCondition;
                _projectContract.ProjectManagerId = projectContract.ProjectManagerId;
                _projectContract.ProjectID = projectContract.ProjectID;
                _projectContract.MainClientId = projectContract.MainClientId;
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