using Microsoft.EntityFrameworkCore;
using WebApiYoutube.Domain.Models.CompanyAggregate;
using WebApiYoutube.Domain.Models.EmployeeAggregate;

namespace WebApiYoutube.Infra
{
    public class ConnectionContext : DbContext
    {
        // O Db set é responsável por mapear no banco de dados e retornar o mapeamento de acordo com a classe
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;" +
                "Database=aulas_webapi_csharp;" +
                "User Id=postgres;" +
                "Password=01021993@Kb;"
            );
        }
    }
}
