using HRMANAGEMENTAPI.Models;
using HRMANAGEMENTAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace HRMANAGEMENTAPI.Controller
{
    [ApiController]
    [Route("api[controller]")]
    public class AttendanceController :ControllerBase
    {
        //readonly
        private readonly IAttendanceRepository _attRepo;

        //inject constructor
        public AttendanceController(IAttendanceRepository attRepo)
        {
            _attRepo = attRepo;
        }


        //Get by Id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendance(int employeeId)
        {
            var today = DateTime.Now;
            var attendance = await _attRepo.GetAttendanceByDateAsync(employeeId , today );
            if(attendance == null)
            return NotFound("No attendance for today");

            return Ok(attendance);
        }

        //Check in
        [HttpPost("checkin/{id}")]
        public async Task<IActionResult>CheckIn(int id)
        {
           
            await _attRepo.CheckInAsync(id);
            return Ok("Checked In Sucessfully");
            
        }

        //Check out
        [HttpPost("checkout/{id}")]
        public async Task<IActionResult>CheckOut(int id)
        {
           
            await _attRepo.CheckOutAsync(id);
            return Ok("Checked Out Sucessfully");
            
        }


        

}
}