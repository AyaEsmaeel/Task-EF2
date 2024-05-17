using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Student_System.Models
{
    public class HomeworkSubmissions
    {
        [Required] public int HomeworkSubmissionsId { get; set; }  
        public string? Content { get; set; }  
        public int CoursesId { get; set; }  
        public int StudentsId { get; set; }  
        public TimeOnly SubmissionTime { get; set; } 
        public ContentType Type { get; set; }
        public enum ContentType        
        {
            Image,
            Video,
            Document,
            Text,
            Application,
            Pdf,
            Zip,
            other
        }
        public Students students { get; set; } = null!;
        public Courses course { get; set; } = null!;
    }
}
