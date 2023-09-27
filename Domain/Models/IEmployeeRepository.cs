using WebApiYoutube.Domain.DTOs;

namespace WebApiYoutube.Domain.Models
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<EmployeeDTO> Get(int pageNumber, int pageQuantity);
        Employee? Get(int id);
    }
}
