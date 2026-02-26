using HRMANAGEMENTAPI.Models;

namespace HRMANAGEMENTAPI.Repository
{
    public  interface IEmployeeRepository
    {
        // List all
        Task<IEnumerable<Employee>> GetAllEmployees();

        //Get by id

        Task<Employee?>GetbyId(int id);

        //Create Employee
        Task CreateEmployee (Employee employee);

        //Update Employee

        Task UpdateEmployee (Employee employee);

        //Delete Post
        Task DeleteEmployee(int id);

       

    }
}