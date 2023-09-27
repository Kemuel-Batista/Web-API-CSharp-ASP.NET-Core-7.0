using WebApiYoutube.Domain.DTOs;
using WebApiYoutube.Domain.Models;

namespace WebApiYoutube.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new();

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChangesAsync();
        }

        public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(b => new EmployeeDTO()
                {
                    Id = b.id,
                    NameEmployee = b.name,
                    Photo = b.photo
                })
                .ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
