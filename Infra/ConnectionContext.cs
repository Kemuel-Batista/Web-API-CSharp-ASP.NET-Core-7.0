using Microsoft.EntityFrameworkCore;
using WebApiYoutube.Domain.Models;

namespace WebApiYoutube.Infra
{
    public class ConnectionContext : DbContext
    {
        // O Db set é responsável por mapear no banco de dados e retornar o mapeamento de acordo com a classe
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;" +
                "Database=aulas_webapi_csharp;" +
                "User Id=postgres;" +
                "Password=123;"
            );
        }
    }
}
