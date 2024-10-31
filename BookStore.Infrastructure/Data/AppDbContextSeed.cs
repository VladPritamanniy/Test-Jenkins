using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure.Data
{
    public static class AppDbContextSeed
    {
        public static async Task MigrateDatabaseAsync(this IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();
        }
    }
}
