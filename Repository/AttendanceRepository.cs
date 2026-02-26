using HRMANAGEMENTAPI.Data;
using HRMANAGEMENTAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace HRMANAGEMENTAPI.Repository
{
    public  class AttendanceRepository : IAttendanceRepository
    {
       //get employee attendance for today

       //ReadyOnly
        private readonly ApplicationDbContext _context;

        //constructor: Inject DbContext via DI
        public AttendanceRepository (ApplicationDbContext context)
        {
             _context = context;
        }

       public async Task<Attendance?> GetAttendanceByDateAsync(int employeeId, DateTime date)
        {
            return await _context.Attendances
            .FirstOrDefaultAsync(a => a.employeeId == employeeId  && a.date == date.Date);
        }

        //check in

        public async Task CheckInAsync(int employeeId)
        {

            //Check if employee exists
            var employeeExists = await _context.Employees
            .AnyAsync(e => e.id == employeeId);

            if (!employeeExists)
                throw new InvalidOperationException("Employee does not exist");
            var today = DateTime.Now;
            var attendance = await GetAttendanceByDateAsync(employeeId,today);

            if (attendance == null)
            {
                attendance = new Attendance
                {
                    employeeId = employeeId,
                    date= today,
                    checkIn = DateTime.Now
                };

                _context.Attendances.Add(attendance);
            }
            else if(!attendance.isCheckedIn)
            {
                attendance.checkIn = DateTime.Now;
                _context.Attendances.Update(attendance);
            }
            await _context.SaveChangesAsync();
        }
        public async Task CheckOutAsync(int employeeId)
        {
            var today = DateTime.Now;
            var attendance = await GetAttendanceByDateAsync(employeeId , today);

            if(attendance == null || attendance.isCheckedOut)
            throw new InvalidOperationException("Cannot check out without checking in");
            
        
            attendance.checkOut = DateTime.Now;
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();

        }


    }
}