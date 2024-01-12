using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using terentevalexandrKt_31_20.Database;
using terentevalexandrKt_31_20.Interfaces.WorkloadInterfaces;
using terentevalexandrKt_31_20.Models;

namespace terentevalexandrKt_31_20.Tests
{
    public class WorkloadIntegrationTests
    {
        public readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public WorkloadIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "project_practice")
            .Options;
        }

        [Fact]
        public async Task AddWorkloadsAsync_workloadObject_Test()
        {
            // Arrange
            var ctx = new ApplicationDbContext(_dbContextOptions);
            var workloadService = new WorkloadService(ctx);
            var professors = new List<Professor>
            {
                new Professor
                {
                    FirstName = "Иван",
                    LastName = "Петров",
                    MiddleName = "Евгеньевич"
                },
                new Professor
                {
                    FirstName = "Олег",
                    LastName = "Зеленов",
                    MiddleName = "Владимирович"
                },
            };
            await ctx.Set<Professor>().AddRangeAsync(professors);

            var educationalsubjects = new List<EducationalSubject>
            {
                new EducationalSubject
                {
                    Name = "Программирование"
                },
                new EducationalSubject
                {
                    Name = "Алгебра и геометрия"
                },
            };
            await ctx.Set<EducationalSubject>().AddRangeAsync(educationalsubjects);

            var workloads = new List<Workload>
            {
                new Workload
                {
                    ProfessorId = 1,
                    EducationalSubjectId = 1,
                    NumberOfHours = 10
                },
                new Workload
                {
                    ProfessorId = 1,
                    EducationalSubjectId = 2,
                    NumberOfHours = 20
                },
                new Workload
                {
                    ProfessorId = 2,
                    EducationalSubjectId = 2,
                    NumberOfHours = 30
                }
            };
            await ctx.Set<Workload>().AddRangeAsync(workloads);

            await ctx.SaveChangesAsync();

            var workload = new Workload
            {
                ProfessorId = 1,
                EducationalSubjectId = 1,
                NumberOfHours = 40
            };
            var workloadResult = await workloadService.AddWorkloadAsync(workload, CancellationToken.None);

            // Assert
            Assert.Equal(4, workloadResult.Id);
            Assert.Equal(1, workloadResult.ProfessorId);
            Assert.Equal(1, workloadResult.EducationalSubjectId);
            Assert.Equal(40, workloadResult.NumberOfHours);
        }
    }
}