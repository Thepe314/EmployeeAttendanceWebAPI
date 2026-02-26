using HRMANAGEMENTAPI.Models;

namespace HRMANAGEMENTAPI.Repository
{
    public interface IAttendanceRepository
    {
        Task<Attendance?> GetAttendanceByDateAsync(int employeeId, DateTime date);
        Task CheckInAsync(int employeeId);
        Task CheckOutAsync(int employeeId);
    }
}