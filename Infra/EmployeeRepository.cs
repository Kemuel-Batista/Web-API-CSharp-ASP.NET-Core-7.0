using WebApiYoutube.Models;

namespace WebApiYoutube.Infra
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new();

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChangesAsync();
        }
        
        public List<Employee> Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
