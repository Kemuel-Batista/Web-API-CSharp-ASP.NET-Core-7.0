using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiYoutube.Models;
using WebApiYoutube.ViewModels;

namespace WebApiYoutube.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            // Pegando o caminho relativo da foto para salvar no banco de dados
            var filePath = Path.Combine("storage", employeeView.Photo.FileName);
            // Utilizando o stream para salvar na pasta storage nos arquivos locais
            using Stream FileStream = new FileStream(filePath, FileMode.Create);
            employeeView.Photo.CopyTo(FileStream);

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);
            _employeeRepository.Add(employee);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeRepository.Get();
            return Ok(employees);
        }
    }
}
