using BookStore.API.Middlewares;
using BookStore.Application.Interfaces;
using BookStore.Application.Mapper;
using BookStore.Application.Services;
using BookStore.Application.Validators;
using BookStore.Core.Repositories.Base;
using BookStore.Infrastructure.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                builder.WebHost.UseUrls("https://0.0.0.0:8081");
            }

            var services = builder.Services;
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"), b => b.MigrationsAssembly("BookStore.Infrastructure")));

            builder.Services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<BookCreateValidator>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            services.AddAutoMapper(typeof(Profiler));

            var app = builder.Build();
            var task = app.Services.MigrateDatabaseAsync();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            await task;
            await app.RunAsync();
        }
    }
}
