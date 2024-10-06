using Microsoft.EntityFrameworkCore;
using SkillUp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SkillUp.DataAccessLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Courses> Courses { get; set; }

        public DbSet<EnrollmentC> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Ensure Identity model configurations are applied

            modelBuilder.Entity<Courses>().HasData
                (
                  new Courses
                  {
                      ID = 1,
                      Title = "A Crash Course in Data Science",
                      Description = "This course is part of the Executive Data Science Specialization ,When you enroll in this course, you'll also be enrolled in this Specialization.1-Learn new concepts from industry experts 2-Gain a foundational understanding of a subject or tool 4-Develop job-relevant skills with hands-on projects 5-Earn a shareable career certificate",
                      InstructorName = "Jeff Leek",
                      Price = 3980,
                      TotalHours = 29,
                      ImgUrl = "defaultImage.jpg"
				  },

                  new Courses
                  {
                      ID = 2,
                      Title = "Blazor - The Complete Guide [.NET 9] [2024] [E-commerce]",
                      Description = "Blazor is an exciting new part of .NET Core (.NET 9) designed for building rich web user interfaces in C#. This course will help developers transition from building basic sample apps to implementing more real world concepts, design patterns, and features.",
                      InstructorName = "Bhrugen Patel",
                      Price = 1250,
                      TotalHours = 12,
                      ImgUrl = "defaultImage.jpg"
				  },

                  new Courses
                  {
                      ID = 3,
                      Title = "Learn to draw fashion with Adobe Illustrator CC - Beginners",
                      Description = "Learn how to use Adobe Illustrator to draw fashion flats. Develop your skills to enable you to produce creative, accurate product designs quickly and to standards required for retail and manufacturing.",
                      InstructorName = "Jo Hughes",
                      Price = 300,
                      TotalHours = 5,
                      ImgUrl = "defaultImage.jpg"
				  },

                  new Courses
                  {
                      ID = 4,
                      Title = "Music Theory",
                      Description = "",
                      InstructorName = "Jonathan Peters",
                      Price = 800,
                      TotalHours = 8,
                      ImgUrl = "defaultImage.jpg"
				  },

                  new Courses
                  {
                      ID = 5,
                      Title = "Introduction to Finance, Accounting, Modeling and Valuation",
                      Description = "This course will help you understand accounting, finance, financial modeling and valuation from scratch (no prior accounting, finance, modeling or valuation experience is required).\r\n\r\nBy the end of this course, you will also know how to value companies using several different valuation methodologies that I have used during my Wall Street career so you can come up with target prices for the companies that you are analyzing.",
                      InstructorName = "Chris Haroun",
                      Price = 2600,
                      TotalHours = 25,
                      ImgUrl = "defaultImage.jpg"
				  },

                  new Courses
                  {
                      ID = 6,
                      Title = "Discrete Mathematics",
                      Description = "Discrete Mathematics (DM), or Discrete Math is the backbone of Mathematics and Computer Science. DM is the study of topics that are discrete rather than continuous, for that, the course is a MUST for any Math or CS student. The topics that are covered in this course are the most essential ones, those that will touch every Math and Science student at some point in their education. ",
                      InstructorName = "Miran Fattah",
                      Price = 1250,
                      TotalHours = 18,
                      ImgUrl = "defaultImage.jpg"
				  }
                );
        }

        }
    }
