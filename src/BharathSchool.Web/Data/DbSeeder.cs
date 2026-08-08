using BharathSchool.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BharathSchool.Web.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var db = services.GetRequiredService<ApplicationDbContext>();

            // Migrate database
            await db.Database.MigrateAsync();

            // Seed roles
            string[] roles = new[] { "SuperAdmin", "Admin", "Principal", "Teacher", "Staff", "Public" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Seed SuperAdmin user
            var superEmail = "superadmin@bharathschool.local";
            var superUser = await userManager.FindByEmailAsync(superEmail);
            if (superUser == null)
            {
                superUser = new ApplicationUser
                {
                    UserName = superEmail,
                    Email = superEmail,
                    FullName = "Super Administrator",
                    EmailConfirmed = true,
                    IsActive = true
                };
                var result = await userManager.CreateAsync(superUser, "P@ssword1!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(superUser, "SuperAdmin");
                }
            }

            // Seed Standards (if not exists)
            if (!db.Standards.Any())
            {
                var standards = new[]
                {
                    new Standard { Name = "Nursery", Order = 0 },
                    new Standard { Name = "LKG", Order = 1 },
                    new Standard { Name = "UKG", Order = 2 },
                    new Standard { Name = "1", Order = 3 },
                    new Standard { Name = "2", Order = 4 },
                    new Standard { Name = "3", Order = 5 },
                    new Standard { Name = "4", Order = 6 },
                    new Standard { Name = "5", Order = 7 },
                    new Standard { Name = "6", Order = 8 },
                    new Standard { Name = "7", Order = 9 },
                    new Standard { Name = "8", Order = 10 },
                    new Standard { Name = "9", Order = 11 },
                    new Standard { Name = "10", Order = 12 },
                    new Standard { Name = "11", Order = 13 },
                    new Standard { Name = "12", Order = 14 }
                };
                await db.Standards.AddRangeAsync(standards);
                await db.SaveChangesAsync();
            }

            // Seed Sections
            if (!db.Sections.Any())
            {
                var standards = await db.Standards.ToListAsync();
                var sections = new List<Section>();
                foreach (var standard in standards.Take(3)) // Add sections for first 3 standards
                {
                    sections.Add(new Section { StandardId = standard.StandardId, Name = "A", Capacity = 40 });
                    sections.Add(new Section { StandardId = standard.StandardId, Name = "B", Capacity = 40 });
                }
                await db.Sections.AddRangeAsync(sections);
                await db.SaveChangesAsync();
            }

            // Seed Subjects
            if (!db.Subjects.Any())
            {
                var subjects = new[]
                {
                    new Subject { Name = "English", Description = "English Language" },
                    new Subject { Name = "Mathematics", Description = "Mathematics" },
                    new Subject { Name = "Science", Description = "Science" },
                    new Subject { Name = "Social Studies", Description = "Social Studies" },
                    new Subject { Name = "Hindi", Description = "Hindi Language" },
                    new Subject { Name = "Physical Education", Description = "PE" },
                    new Subject { Name = "Computer Science", Description = "CS" },
                    new Subject { Name = "Art", Description = "Art and Crafts" }
                };
                await db.Subjects.AddRangeAsync(subjects);
                await db.SaveChangesAsync();
            }

            // Seed Students
            if (!db.Students.Any())
            {
                var standard = await db.Standards.FirstAsync();
                var section = await db.Sections.FirstAsync();
                var students = new[]
                {
                    new Student
                    {
                        FirstName = "Aarav",
                        LastName = "Sharma",
                        DOB = new DateTime(2015, 5, 10),
                        Gender = "Male",
                        StandardId = standard.StandardId,
                        SectionId = section.SectionId,
                        AdmissionStatus = "Active",
                        ParentName = "Rajesh Sharma",
                        ParentContact = "9876543210",
                        Address = "123 Main Street, City"
                    },
                    new Student
                    {
                        FirstName = "Ananya",
                        LastName = "Verma",
                        DOB = new DateTime(2015, 8, 22),
                        Gender = "Female",
                        StandardId = standard.StandardId,
                        SectionId = section.SectionId,
                        AdmissionStatus = "Active",
                        ParentName = "Vikram Verma",
                        ParentContact = "9876543211",
                        Address = "456 Oak Avenue, City"
                    },
                    new Student
                    {
                        FirstName = "Arjun",
                        LastName = "Patel",
                        DOB = new DateTime(2015, 3, 15),
                        Gender = "Male",
                        StandardId = standard.StandardId,
                        SectionId = section.SectionId,
                        AdmissionStatus = "Active",
                        ParentName = "Mukesh Patel",
                        ParentContact = "9876543212",
                        Address = "789 Pine Road, City"
                    }
                };
                await db.Students.AddRangeAsync(students);
                await db.SaveChangesAsync();
            }

            // Seed Teachers
            if (!db.Teachers.Any())
            {
                // Create teacher users
                var teacher1Email = "teacher1@bharathschool.local";
                var teacher1 = await userManager.FindByEmailAsync(teacher1Email);
                if (teacher1 == null)
                {
                    teacher1 = new ApplicationUser
                    {
                        UserName = teacher1Email,
                        Email = teacher1Email,
                        FullName = "Mrs. Priya Singh",
                        EmailConfirmed = true,
                        IsActive = true
                    };
                    var result = await userManager.CreateAsync(teacher1, "Teacher@123");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(teacher1, "Teacher");
                    }
                }

                var teacher2Email = "teacher2@bharathschool.local";
                var teacher2 = await userManager.FindByEmailAsync(teacher2Email);
                if (teacher2 == null)
                {
                    teacher2 = new ApplicationUser
                    {
                        UserName = teacher2Email,
                        Email = teacher2Email,
                        FullName = "Mr. Amit Kumar",
                        EmailConfirmed = true,
                        IsActive = true
                    };
                    var result = await userManager.CreateAsync(teacher2, "Teacher@123");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(teacher2, "Teacher");
                    }
                }

                // Create teacher records
                if (!db.Teachers.Any(t => t.UserId == Guid.Parse(teacher1.Id)))
                {
                    var teachers = new[]
                    {
                        new Teacher
                        {
                            UserId = Guid.Parse(teacher1.Id),
                            Designation = "Senior Teacher",
                            JoiningDate = new DateTime(2020, 6, 15)
                        },
                        new Teacher
                        {
                            UserId = Guid.Parse(teacher2.Id),
                            Designation = "Teacher",
                            JoiningDate = new DateTime(2021, 7, 1)
                        }
                    };
                    await db.Teachers.AddRangeAsync(teachers);
                    await db.SaveChangesAsync();
                }
            }

            // Seed Coaches
            if (!db.Coaches.Any())
            {
                var coaches = new[]
                {
                    new Coach { Name = "Mr. Rajesh Kumar", Contact = "9876543220" },
                    new Coach { Name = "Mr. Sanjay Singh", Contact = "9876543221" }
                };
                await db.Coaches.AddRangeAsync(coaches);
                await db.SaveChangesAsync();
            }

            // Seed Sports
            if (!db.Sports.Any())
            {
                var coaches = await db.Coaches.ToListAsync();
                var sports = new[]
                {
                    new Sport { Name = "Cricket", IsCoached = true, CoachId = coaches.FirstOrDefault()?.CoachId },
                    new Sport { Name = "Football", IsCoached = true, CoachId = coaches.Skip(1).FirstOrDefault()?.CoachId },
                    new Sport { Name = "Basketball", IsCoached = false },
                    new Sport { Name = "Volleyball", IsCoached = false },
                    new Sport { Name = "Tennis", IsCoached = false },
                    new Sport { Name = "Badminton", IsCoached = false }
                };
                await db.Sports.AddRangeAsync(sports);
                await db.SaveChangesAsync();
            }

            // Seed Fees
            if (!db.Fees.Any())
            {
                var standards = await db.Standards.Take(5).ToListAsync();
                var fees = new List<Fee>();
                foreach (var standard in standards)
                {
                    fees.Add(new Fee
                    {
                        StandardId = standard.StandardId,
                        Term = "Term 1",
                        TuitionFee = 5000,
                        BookFee = 2000,
                        UniformFee = 1500,
                        ShoesFee = 800,
                        SportsDressFee = 500,
                        BusFee = 1000,
                        OtherFees = "Lab Fee: 500"
                    });
                    fees.Add(new Fee
                    {
                        StandardId = standard.StandardId,
                        Term = "Term 2",
                        TuitionFee = 5000,
                        BookFee = 1500,
                        UniformFee = 0,
                        ShoesFee = 0,
                        SportsDressFee = 500,
                        BusFee = 1000,
                        OtherFees = "Lab Fee: 500"
                    });
                }
                await db.Fees.AddRangeAsync(fees);
                await db.SaveChangesAsync();
            }

            // Seed Bus Routes
            if (!db.BusRoutes.Any())
            {
                var routes = new[]
                {
                    new BusRoute { Name = "Route A - North", Description = "Covering North City areas" },
                    new BusRoute { Name = "Route B - South", Description = "Covering South City areas" },
                    new BusRoute { Name = "Route C - East", Description = "Covering East City areas" }
                };
                await db.BusRoutes.AddRangeAsync(routes);
                await db.SaveChangesAsync();
            }

            // Seed Bus Stops
            if (!db.BusStops.Any())
            {
                var routes = await db.BusRoutes.ToListAsync();
                var stops = new List<BusStop>();

                if (routes.Any())
                {
                    var route = routes.First();
                    stops.AddRange(new[]
                    {
                        new BusStop { BusRouteId = route.BusRouteId, StopName = "Central Station", PickupOrder = 1, Latitude = 28.6139M, Longitude = 77.2090M },
                        new BusStop { BusRouteId = route.BusRouteId, StopName = "Market Square", PickupOrder = 2, Latitude = 28.6155M, Longitude = 77.2100M },
                        new BusStop { BusRouteId = route.BusRouteId, StopName = "School Gate", PickupOrder = 3, Latitude = 28.6200M, Longitude = 77.2150M }
                    });
                }

                await db.BusStops.AddRangeAsync(stops);
                await db.SaveChangesAsync();
            }

            // Seed Activities
            if (!db.Activities.Any())
            {
                var activities = new[]
                {
                     new Activity
                    {
                        Title = "Annual Day 2024",
                        ActivityType = "Annual Day",
                        ActivityDate = new DateTime(2024, 3, 15),
                        Description = "School's annual cultural extravaganza showcasing talent and achievements",
                        CreatedBy = Guid.Parse(superUser.Id)
                    },
                    new Activity
                    {
                        Title = "Sports Day 2024",
                        ActivityType = "Sports Day",
                        ActivityDate = new DateTime(2024, 2, 10),
                        Description = "Inter-house sports competition featuring various athletic events",
                        CreatedBy = Guid.Parse(superUser.Id)
                    },
                    new Activity
                    {
                        Title = "Parent-Teacher Meeting",
                        ActivityType = "Parent Meet",
                        ActivityDate = new DateTime(2024, 1, 20),
                        Description = "Quarterly meeting to discuss student progress and development",
                        CreatedBy = Guid.Parse(superUser.Id)
                    },
                    new Activity
                    {
                        Title = "Science Exhibition",
                        ActivityType = "Exhibition",
                        ActivityDate = new DateTime(2024, 4, 5),
                        Description = "Students showcase innovative science projects and experiments",
                        CreatedBy = Guid.Parse(superUser.Id)
                    }
                };
                await db.Activities.AddRangeAsync(activities);
                await db.SaveChangesAsync();
            }

            // Seed Achievements (Ranks)
            if (!db.Achievements.Any())
            {
                var students = await db.Students.Take(3).ToListAsync();
                var achievements = new List<Achievement>();

                if (students.Count > 0)
                {
                    achievements.Add(new Achievement
                    {
                        StudentId = students[0].StudentId,
                        Year = 2024,
                        Rank = 1,
                        Title = "Rank 1 - Academic Excellence",
                        Remarks = "Outstanding performance in all subjects"
                    });
                }

                if (students.Count > 1)
                {
                    achievements.Add(new Achievement
                    {
                        StudentId = students[1].StudentId,
                        Year = 2024,
                        Rank = 2,
                        Title = "Rank 2 - Science",
                        Remarks = "Excellence in Science stream"
                    });
                }

                if (students.Count > 2)
                {
                    achievements.Add(new Achievement
                    {
                        StudentId = students[2].StudentId,
                        Year = 2024,
                        Rank = 3,
                        Title = "Rank 3 - Mathematics",
                        Remarks = "Outstanding Mathematics performance"
                    });
                }

                if (achievements.Any())
                {
                    await db.Achievements.AddRangeAsync(achievements);
                    await db.SaveChangesAsync();
                }
            }

            // Seed Site Settings
            if (!db.SiteSettings.Any())
            {
                var settings = new[]
                {
                    new SiteSetting { SettingKey = "SchoolName", SettingValue = "Bharath Nursery and Secondary School" },
                    new SiteSetting { SettingKey = "SchoolAddress", SettingValue = "123 Education Lane, City, State 12345" },
                    new SiteSetting { SettingKey = "SchoolPhone", SettingValue = "+91-9876543210" },
                    new SiteSetting { SettingKey = "SchoolEmail", SettingValue = "info@bharathschool.local" },
                    new SiteSetting { SettingKey = "PrincipalName", SettingValue = "Dr. Ramesh Sharma" },
                    new SiteSetting { SettingKey = "CorrespondentName", SettingValue = "Mr. Vikram Singh" },
                    new SiteSetting { SettingKey = "FounderName", SettingValue = "Late Mr. Bharat Nath" },
                    new SiteSetting { SettingKey = "EstablishedYear", SettingValue = "1995" },
                    new SiteSetting { SettingKey = "SchoolWebsite", SettingValue = "https://bharathschool.edu.in" },
                    new SiteSetting { SettingKey = "FacebookPage", SettingValue = "https://facebook.com/bharathschool" },
                    new SiteSetting { SettingKey = "InstagramHandle", SettingValue = "https://instagram.com/bharathschool" }
                };
                await db.SiteSettings.AddRangeAsync(settings);
                await db.SaveChangesAsync();
            }
        }
    }
}



