using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Student_System.Models
{
    public class Courses
    {
        [Required] public int CoursesId { get; set; }
        public string? Description { get; set; } 
        public DateOnly EndDate { get; set; }
        public string? Name { get; set; }   
        public decimal Price { get; set; }
        public DateOnly StartDate { get; set;}
        public List<HomeworkSubmissions> HomeworkEnrolled { get; set; } = new List<HomeworkSubmissions>();
        public List<Resources> resources { get; set; } = new List<Resources>();
        public List<Students> students { get; set; } = new List<Students>();
    }
}
