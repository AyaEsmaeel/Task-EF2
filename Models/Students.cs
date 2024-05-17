using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace P01_Student_System.Models
{
    public class Students
    {
        [Required] public int StudentsId { get; set; } 
        public DateOnly? Birthday { get; set; } = new DateOnly();
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }= new DateTime();
        public List<HomeworkSubmissions> HomeworkEnrolled { get; set; } = new List<HomeworkSubmissions>();
        public List<Courses> Courses { get; set; }  =new List<Courses>();


    }
}
