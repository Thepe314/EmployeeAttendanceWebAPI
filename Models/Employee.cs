using System.ComponentModel.DataAnnotations;

namespace HRMANAGEMENTAPI.Models
{
    public class Employee
{
       //Attributes of Employee

       public int id{get;set;}

       public required string Name{get;set;}

       public required string Email{get;set;}

       public required string Department{get;set;}

        // Navigation property 
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();






}

}

