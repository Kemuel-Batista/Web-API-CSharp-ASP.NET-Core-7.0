namespace WebApiYoutube.Models
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<Employee> Get();
    }
}
