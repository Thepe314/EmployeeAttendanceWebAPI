using System.ComponentModel.DataAnnotations;

namespace HRMANAGEMENTAPI.Models
{
    public class Attendance
{
       //Attributes of Employee

       public int id{get;set;}

        public int employeeId{get;set;}
       
        public Employee employee {get;set;} = null!;

        public DateTime date{get;set;} =DateTime.Now;

        public DateTime? checkIn{get;set;}

        public DateTime? checkOut{get;set;}

        public bool isCheckedIn => checkIn.HasValue;

        public bool isCheckedOut => checkOut.HasValue;
        


}

}

