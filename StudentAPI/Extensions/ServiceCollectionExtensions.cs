using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentAPI.DALs;
using StudentAPI.DALs.Queries;
using StudentAPI.Services;

namespace StudentAPI.Controllers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IStudentQueryRepository, StudentQueryRepository>()
                //.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
                //.AddScoped<IDepartmentRepository, DepartmentRepository>()
                ;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration) => services.AddDbContext<PracticeDbContext>(options =>
                                                                 options.UseSqlServer(configuration.GetConnectionString("MyWorldDbConnection")));

        public static IServiceCollection AddBusinessServices(this IServiceCollection services
           )
        {
            return services.AddScoped<IStudentService,StudentService>();
        }
    }
}
