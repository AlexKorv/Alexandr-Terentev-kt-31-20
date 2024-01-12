using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using terentevalexandrKt_31_20.Database;
using terentevalexandrKt_31_20.Models;


namespace terentevalexandrKt_31_20.Interfaces.WorkloadInterfaces
{
    public interface IWorkloadService
    {
        public Task<Workload> AddWorkloadAsync(Workload workload, CancellationToken cancellationToken);
        public Task<Workload> UpdateWorkloadAsync(Workload workload, CancellationToken cancellationToken);
    }

    public class WorkloadService : IWorkloadService
    {
        private readonly ApplicationDbContext _dbContext;
        public WorkloadService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Workload> AddWorkloadAsync(Workload workload, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(workload);

            await _dbContext.SaveChangesAsync();

            return workload;
        }

        public async Task<Workload> UpdateWorkloadAsync(Workload workload, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(workload);

            await _dbContext.SaveChangesAsync();

            return workload;
        }
    }
}
