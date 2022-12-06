
using Microsoft.EntityFrameworkCore;
using StudentAPI.Controllers.Extensions;
using StudentAPI.DALs;

namespace StudentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            //builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //ServiceCollectionExtensions
            builder.Services.AddRepositories()
                            .AddUnitOfWork()
                            .AddBusinessServices()
                            .AddDatabase(builder.Configuration);

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}