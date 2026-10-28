using System;
using System.Collections.Generic;

namespace CourseRegistration
{
class Program
{
static void Main(string[] args)
{
CourseService course = new CourseService(2);

Console.WriteLine(course.Enroll("StudentA", true));
Console.WriteLine(course.Enroll("StudentB", true));
Console.WriteLine(course.Enroll("StudentC", true));
Console.WriteLine(course.Enroll("StudentD", false));

Console.WriteLine("\nDropping StudentA");
Console.WriteLine(course.Drop("StudentA"));

//course.ShowStatus();
Console.WriteLine("\nEnrolled Count: " + course.EnrolledCount);
Console.WriteLine("Available Seats: " + course.AvailableSeats);
Console.WriteLine("\nWaitlist:");
foreach(string id in course.GetWaitlist())
{Console.WriteLine(id);}
//Console.ReadLine();
}
}
}