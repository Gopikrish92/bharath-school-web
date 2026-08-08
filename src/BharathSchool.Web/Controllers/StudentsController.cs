using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BharathSchool.Web.Data;
using BharathSchool.Web.Models;
using BharathSchool.Web.ViewModels;
using BharathSchool.Web.Services;

namespace BharathSchool.Web.Controllers
{
    [Authorize(Roles = "Admin,Principal,Teacher")]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileUploadService _fileUploadService;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(
            ApplicationDbContext db,
            IFileUploadService fileUploadService,
            ILogger<StudentsController> logger)
        {
            _db = db;
            _fileUploadService = fileUploadService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var students = await _db.Students
                    .Include(s => s.Standard)
                    .Include(s => s.Section)
                    .OrderBy(s => s.FirstName)
                    .ToListAsync();

                return View(students);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching students: {ex.Message}");
                return View(new List<Student>());
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var student = await _db.Students
                    .Include(s => s.Standard)
                    .Include(s => s.Section)
                    .FirstOrDefaultAsync(s => s.StudentId == id);

                if (student == null)
                {
                    return NotFound();
                }

                return View(student);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching student details: {ex.Message}");
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewBag.Standards = await _db.Standards
                    .OrderBy(s => s.Order)
                    .ToListAsync();
                ViewBag.Sections = await _db.Sections.ToListAsync();

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading create form: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Standards = await _db.Standards.OrderBy(s => s.Order).ToListAsync();
                ViewBag.Sections = await _db
