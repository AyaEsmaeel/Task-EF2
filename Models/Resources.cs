using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Student_System.Models
{
    public class Resources
    {
        [Required] public int ResourcesId { get; set; }  
        public int CoursesId { get; set;}  
        public string? Name { get; set; }  
        public string? Url { get; set; }  
        public ResourceType Type { get; set; } 
        public enum ResourceType
        {
            Video,
            Presentation,
            Document,
            image,
            pdf,
            text,
            other
        }
        public Courses course { get; set; } = null!;
    }
}
