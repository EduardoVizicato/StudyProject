using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client.Extensions.Msal;
using StudyAPI.Model;
using StudyAPI.Model.Requests;
using System.Reflection.Metadata.Ecma335;

namespace StudyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeRepository repository) : ControllerBase
    {
        private readonly IEmployeeRepository _repository = repository;
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeRequest request)
        {
            var filePath = Path.Combine("Storage", request.Photo.Name);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            request.Photo.CopyTo(fileStream);
            var employee = new Employee(
                request.Name,
                request.Age,
                filePath);
            if (employee == null)
            {
                return BadRequest();
            }

            _repository.Add(employee);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employee = _repository.GetAll();

            return Ok(employee);
        }

        [HttpPost("{id}/download")]

        public IActionResult DownLoadPhoto(int id) 
        {
            var employee = _repository.GetById(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.Photo);

            return File(dataBytes, "image/jpg");
        }
    }
}
