using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Linq;
using terentevalexandrKt_31_20.Database;
using terentevalexandrKt_31_20.Models;
using terentevalexandrKt_31_20.Filters.WorkloadFilters;


namespace terentevalexandrKt_31_20.Interfaces.WorkloadInterfaces
{
    public interface IWorkloadService
    {
        public Task<Workload> AddWorkloadAsync(Workload workload, CancellationToken cancellationToken);
        public Task<Workload> UpdateWorkloadAsync(Workload workload, CancellationToken cancellationToken);
        public Task<Workload[]> GetWorkloadsBProfessorAsync(WorkloadProfessorFilter filter, CancellationToken cancellationToken = default);
        public Task<Workload[]> GetWorkloadsByEducationalSubjectAsync(WorkloadEducationalSubjectFilter filter, CancellationToken cancellationToken = default);
        public Task<Professor[]> GetProfessorsByEducationalSubjectAsync(int id, CancellationToken cancellationToken = default);
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

        public Task<Workload[]> GetWorkloadsBProfessorAsync(WorkloadProfessorFilter filter, CancellationToken cancellationToken = default)
        {
            var workloads = _dbContext.Set<Workload>().Where(w => w.Professor.LastName == filter.LastName).ToArrayAsync(cancellationToken);

            return workloads;
        }

        public Task<Workload[]> GetWorkloadsByEducationalSubjectAsync(WorkloadEducationalSubjectFilter filter, CancellationToken cancellationToken = default)
        {
            var workloads = _dbContext.Set<Workload>().Where(w => w.EducationalSubjectId == filter.Id).ToArrayAsync(cancellationToken);

            return workloads;
        }

        public Task<Professor[]> GetProfessorsByEducationalSubjectAsync(int id, CancellationToken cancellationToken = default)
        {
            var workloads = _dbContext.Set<Workload>().Where(w => w.EducationalSubjectId == id).Select(s => s.ProfessorId).ToArray();
            var professors = _dbContext.Set<Professor>().Where(w => workloads.Contains(w.Id)).ToArrayAsync(cancellationToken);

            return professors;
        }
    }
}
