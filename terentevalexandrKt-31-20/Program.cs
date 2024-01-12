using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using terentevalexandrKt_31_20.Models;
using terentevalexandrKt_31_20.Database;
using terentevalexandrKt_31_20.ServiceExtensions;
using terentevalexandrKt_31_20.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddServices();

    var app = builder.Build();

    initData().Wait();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ExceptionHandlerMiddleware>();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    async Task initData()
    {
        var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var professor = new Professor
        {
            Id = 1,
            FirstName = "Антон",
            LastName = "Петров",
            MiddleName = "Сергеевич"
        };
        if (await _context.Set<Professor>()
            .FindAsync(professor.Id)
            == null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT professor ON");
                    _context.Add(professor);
                    await _context.SaveChangesAsync();
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT professor OFF");
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        var professor2 = new Professor
        {
            Id = 2,
            FirstName = "Сергей",
            LastName = "Иванов",
            MiddleName = "Андреевич"
        };
        if (await _context.Set<Professor>()
            .FindAsync(professor2.Id)
            == null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT professor ON");
                    _context.Add(professor2);
                    await _context.SaveChangesAsync();
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT professor OFF");
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        var educationalsubject = new EducationalSubject
        {
            Id = 1,
            Name = "Программирование"
        };
        if (await _context.Set<EducationalSubject>()
            .FindAsync(educationalsubject.Id)
            == null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT educationalsubject ON");
                    _context.Add(educationalsubject);
                    await _context.SaveChangesAsync();
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT educationalsubject OFF");
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        var educationalsubject2 = new EducationalSubject
        {
            Id = 1,
            Name = "Алгебра и геометрия"
        };
        if (await _context.Set<EducationalSubject>()
            .FindAsync(educationalsubject2.Id)
            == null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT educationalsubject ON");
                    _context.Add(educationalsubject2);
                    await _context.SaveChangesAsync();
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT educationalsubject OFF");
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
catch(Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
}
finally
{
    LogManager.Shutdown();
}




