using Microsoft.EntityFrameworkCore;
using HtthLab01.Models;

namespace HtthLab01.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Majors.Any())
                {
                    return;
                }

                var majors = new Major[] {
                    new Major{MajorName="IT"},
                    new Major{MajorName="Kinh tế"},
                    new Major{MajorName="Công trình"}
                };
                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();

                
                var learners = new Learner[] {
                    new Learner { FirstMidName = "Minh", LastName = "Anh", EnrollmentDate = DateTime.Parse("2005-09-01"), MajorID = 1 },
                    new Learner { FirstMidName = "Lan", LastName = "Mai", EnrollmentDate = DateTime.Parse("2002-09-01"), MajorID = 2 }
                };
                foreach (Learner l in learners)
                {
                    context.Learners.Add(l);
                }
                context.SaveChanges();

          
                var courses = new Course[] {
                    new Course{CourseID = 1050, Title="Hóa học", Credits = 3},
                    new Course{CourseID = 4022, Title="Vật lý", Credits = 3},
                    new Course{CourseID = 4041, Title="Toán", Credits = 3}
                };
                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();

             
                var enrollments = new Enrollment[]{
                    new Enrollment {LearnerID = 1, CourseID = 1050, Grade = 5.5f},
                    new Enrollment {LearnerID = 1, CourseID = 4022, Grade = 7.5f},
                    new Enrollment {LearnerID = 2, CourseID = 1050, Grade = 3.5f},
                    new Enrollment {LearnerID = 2, CourseID = 4041, Grade = 7f}
                };
                foreach (Enrollment e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}