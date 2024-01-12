using Microsoft.AspNetCore.Mvc;
using terentevalexandrKt_31_20.Database;
using terentevalexandrKt_31_20.Interfaces.WorkloadInterfaces;
using terentevalexandrKt_31_20.Models;

namespace terentevalexandrKt_31_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkloadsController : ControllerBase
    {
        private readonly ILogger<WorkloadsController> _logger;
        private readonly IWorkloadService _workloadService;
        private readonly ApplicationDbContext _dbContext;

        public WorkloadsController(ApplicationDbContext dbContext, ILogger<WorkloadsController> logger, IWorkloadService workloadService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _workloadService = workloadService;
        }

        [HttpPost("AddWorkload")]
        public async Task<IActionResult> AddWorkloadAsync(Workload workload, CancellationToken cancellationToken = default)
        {
            workload.Professor = _dbContext.Set<Professor>().Find(workload.ProfessorId);
            workload.EducationalSubject = _dbContext.Set<EducationalSubject>().Find(workload.EducationalSubjectId);
            var resp = await _workloadService.AddWorkloadAsync(workload, cancellationToken);

            return Ok(resp);
        }

        [HttpPut("UpdateWorkload")]
        public async Task<IActionResult> UpdateWorkloadAsync(Workload workload, CancellationToken cancellationToken = default)
        {
            workload.Professor = _dbContext.Set<Professor>().Find(workload.ProfessorId);
            workload.EducationalSubject = _dbContext.Set<EducationalSubject>().Find(workload.EducationalSubjectId);
            var resp = await _workloadService.UpdateWorkloadAsync(workload, cancellationToken);

            return Ok(resp);
        }
    }
}
