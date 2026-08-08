using Microsoft.AspNetCore.Mvc;
using BharathSchool.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BharathSchool.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Get statistics for dashboard
                var studentCount = await _db.Students.CountAsync();
                var standardCount = await _db.Standards.CountAsync();
                var teacherCount = await _db.Teachers.CountAsync();
                var activityCount = await _db.Activities.CountAsync();

                ViewBag.StudentCount = studentCount;
                ViewBag.StandardCount = standardCount;
                ViewBag.TeacherCount = teacherCount;
                ViewBag.ActivityCount = activityCount;

                // Get recent activities
                var recentActivities = await _db.Activities
                    .OrderByDescending(a => a.CreatedAt)
                    .Take(5)
                    .ToListAsync();

                // Get top achievers
                var topAchievers = await _db.Achievements
                    .OrderBy(a => a.Rank)
                    .Take(3)
                    .Include(a => a.Student)
                    .ToListAsync();

                ViewBag.RecentActivities = recentActivities;
                ViewBag.TopAchievers = topAchievers;

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Home Index: {ex.Message}");
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}

