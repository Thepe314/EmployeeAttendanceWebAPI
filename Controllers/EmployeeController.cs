using HRMANAGEMENTAPI.Models;
using HRMANAGEMENTAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace HRMANAGEMENTAPI.Controller
{
    [ApiController]
    [Route("api[controller]")]
    public class EmployeeController :ControllerBase
    {
        //readonly
        private readonly IEmployeeRepository _empRepo;

        //inject constructor
        public EmployeeController(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployee() 
        {

           var employees = await _empRepo.GetAllEmployees();
           return Ok(employees);
        
        }

        //Get by Id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _empRepo.GetbyId(id);
            return Ok(employee);
        }

        //Create employee
        [HttpPost]
        public async Task<IActionResult>CreateEmployee(EmployeeCreateDto dto)
        {
            //map Dto to Entity
            var employee =new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                Department = dto.Department,

            };

            await _empRepo.CreateEmployee(employee);
            return Ok("Post Successfully created");

        
        }

        //Update employee
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateEmployee(int id, EmployeeCreateDto dto)
        {
            var existing = await _empRepo.GetbyId(id);
            if(existing ==null)
            return NotFound("Employee not found");

            existing.Name = dto.Name;
            existing.Email = dto.Email;
            existing.Department = dto.Department;

            await _empRepo.UpdateEmployee(existing);
            return Ok("Post Updated Successfully");

        
        }

        //Delete employee
        [HttpPost("{id}")]
        public async Task<IActionResult>DeleteEmployee(int id)
        {
            var existing = await _empRepo.GetbyId(id);
            if(existing ==null!) return NotFound("Missing id");

            await _empRepo.DeleteEmployee(id);
            return Ok("Post Successfully Deleted");

        
        }

}
}