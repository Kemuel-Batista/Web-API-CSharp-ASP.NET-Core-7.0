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
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            //_logger.Log(LogLevel.Error, "Teve um erro");

            var employees = _employeeRepository.Get(pageNumber, pageQuantity);

            //_logger.LogInformation("Teste");

            return Ok(employees);
        }
    }
}
