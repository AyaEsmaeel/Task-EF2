using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;
using P01_Student_System.Data;
using P01_Student_System.Models;
using System.Net;
using System.Net.Mime;
using System.Security.AccessControl;

internal class Program
{

    static void Main(string[] args)
    {
        Courses courses = new Courses();
        Students students = new Students();
        Resources resources = new Resources();
        HomeworkSubmissions homeworkSubmissions = new HomeworkSubmissions();
        StudentSystemContext context = new StudentSystemContext(); 


        //AddStudent: 5 students

        List<string> studentNames = new List<string> {"Aya Esmaeel","Asmaa Mohamed","Aya Salah","Doaa Ahmed","Norhan Ahmed"};
        List<DateOnly> studentBirths = new List<DateOnly>(){new(2003, 8, 3),new(2003,1,1),new(2003, 5, 5),new(2002,12,6),new(2002,12,30)};
        List<string> StudentsPhone = new List<string> {"0111455","0124454","0223313","015654645","012453535"};
        List<DateTime> studentsRegist = new List<DateTime>(){
            new(2021, 5, 17, 21, 10, 0),new(2021, 5, 18, 22, 8, 0),new(2021, 5, 1, 18, 7, 3),new(2021, 5, 20, 5, 10, 9),new(2021, 5, 3, 21, 4, 10)
        };
        for(int i = 0; i < 5; i++)
        {
            Students student = new Students()
            {
                Birthday = studentBirths[i],
                Name = studentNames[i],
                PhoneNumber = StudentsPhone[i],
                RegisteredOn = studentsRegist[i],
            };
            context.student.Add(student);
        }
        //AddCourse: 5 Courses

        List<string> CoursesDiscriptions = new List<string> { "MATH202", "Phy203","Chem204","Stat205","Cs206"};
        List<string> CourseNames = new List<string>() {"Mathematics","Physics","Chemistry","Statistics","ComputerScience"};
        List<decimal> CoursePrices = new List<decimal>(){300,500,455,333,800};
        List<DateOnly> CoursesStart = new List<DateOnly>() {new(2024, 10, 1), new(2024, 10, 2), new(2024, 10, 3), new(2024, 10, 4), new(2024, 10, 5) };
        List<DateOnly> CoursesEnd = new List<DateOnly>() {new(2024, 12, 1), new(2024, 12, 2), new(2024, 12, 3), new(2024, 12, 4), new(2024, 12, 5) };

        for (int i = 0; i < 5 ; i++)
        {
            Courses course = new Courses()
            {
                Description = CoursesDiscriptions[i],
                EndDate = CoursesEnd[i],
                Name = CourseNames[i],
                Price = CoursePrices[i],
                StartDate = CoursesStart[i],
            };
            context.course.Add(course);
        }
        //AddResources: 5 Resources

        List<string> ResourcesName = new List<string>() { "Mathematics", "Physics", "Chemistry", "Statistics", "ComputerScience" };
        List<string> ResourcesUrl = new List<string>() { "Mathematics", "Physics", "Chemistry", "Statistics", "ComputerScience" };
        List<Resources.ResourceType> ResourceType = new List<Resources.ResourceType>() {
            Resources.ResourceType.Video,
            Resources.ResourceType.text,
            Resources.ResourceType.pdf,
            Resources.ResourceType.Document,
            Resources.ResourceType.other,
        };

        for (int i = 0; i < 5 ; i++)
        {
           Resources resource = new Resources()
            {
               CoursesId = i + 1,
               Name = ResourcesName[i],
                Type = ResourceType[i],
                Url = ResourcesUrl[i],
            };
            context.resource.Add(resource);
        }
        //AddSubmissions: 5 Homeworks
        List<TimeOnly> TimeOnly = new List<TimeOnly>() {new(21,10,0),new(22,3,5),new(21,44,9),new(20,9,10),new(20,8,5)};
        List<string> ContentLink = new List<string>() {
            """C:\Users\DELL\source\repos\Task4\Task4\New folder\Account.cs""",
            """C:\Users\DELL\Pictures\Screenshots\image1.pngC:\Users\DELL\Pictures\Screenshots\image1.png""",
            """C:\Users\DELL\OneDrive - Faculty of Science,IV - POS -- Stemming\Recordings\Part of Speech (POS)-20240330_155428-Meeting Recording.mp4""",
            """C:\Users\DELL\OneDrive - Faculty of Science, Helwan University\space\OneDrive - Faculty of Science, Helwan University\Document29.docx""",
            """C:\Users\DELL\Downloads\EF-Core-Exercises.pdf"""
        };
        List<HomeworkSubmissions.ContentType> ContentType = new List<HomeworkSubmissions.ContentType>(){
            HomeworkSubmissions.ContentType.Application,
            HomeworkSubmissions.ContentType.Image,
            HomeworkSubmissions.ContentType.Video,
            HomeworkSubmissions.ContentType.Text,
            HomeworkSubmissions.ContentType.Pdf,
        };
        for(int i = 0;i < 5 ; i++)
        {

            HomeworkSubmissions HomeWork = new HomeworkSubmissions()
            {
                CoursesId = i+1,
                StudentsId = i+1,
                Content = ContentLink[i],
                Type = ContentType[i],
                SubmissionTime = TimeOnly[i],
            };
            context.Homework.Add(HomeWork);
        };
        context.SaveChanges();
    }
}