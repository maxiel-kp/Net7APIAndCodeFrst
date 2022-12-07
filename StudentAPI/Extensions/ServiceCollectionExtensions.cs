using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentAPI.CQRS.Queries;
using StudentAPI.DALs;
using StudentAPI.DALs.Queries;
using StudentAPI.DTOs.DTOs;
using StudentAPI.DTOs.Requests;
using StudentAPI.Services.Queries;

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
            return services
                .AddScoped<IStudentService, StudentService>();
        }

        //AddMediatR
        public static void RegisterMediatRDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(StudentQueryHandler).Assembly)
                .AddTransient<IRequestHandler<GetUserRequest, UserInfoDTO>, StudentQueryHandler>();
            //.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
