using HRMANAGEMENTAPI.Data;
using HRMANAGEMENTAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace HRMANAGEMENTAPI.Repository
{
        public class EmployeeRepository : IEmployeeRepository

    {
        
        //ReadyOnly
        private readonly ApplicationDbContext _context;

        //constructor: Inject DbContext via DI
        public EmployeeRepository (ApplicationDbContext context)
        {
             _context = context;
        }

        //Get all 
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // get by id 
        public async Task<Employee?> GetbyId(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        //create new employee

        public async Task CreateEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        //Update Employee
        public async Task UpdateEmployee(Employee employee)
        {
            var existing  = await _context.Employees.FindAsync(employee.id);
            if(existing ==null!) return;

            existing.Name = employee.Name;
            existing.Email = employee.Email;
            existing.Department=existing.Department;

            await _context.SaveChangesAsync();
        }

        //Delete Employee
        public async Task DeleteEmployee(int id)
        {
            var existing = await _context.Employees.FindAsync(id);
            if(existing == null!) return;
            _context.Employees.Remove(existing);

            await _context.SaveChangesAsync();
        }

        
        
           
    }
}
