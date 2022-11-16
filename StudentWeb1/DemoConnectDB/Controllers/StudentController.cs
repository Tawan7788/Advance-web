using AdvanceWeb.Data;
using AdvanceWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdvanceWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private object filename;

        public StudentController (StudentContext context,IWebHostEnvironment hostEnvironment){
            _context = context; 
            _hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var student = await _context.Student.ToListAsync();
            return View(student);
        }

        public async Task<IActionResult> Subject()
        {
            var subject = await _context.Subject.ToListAsync();
            return View(subject);
        }

        public IActionResult Create()
        {
            return View();
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            string filename = Uploadfile(student);
            var s = new Student
            {
                stuid = student.stuid,
                stuname = student.stuname,
                stulastname = student.stulastname,
                stuaddress = student.stuaddress,
                stuphone = student.stuphone,
                GPA= student.GPA,
                stuimg = filename
            };

            _context.Student.Add(s);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        private string Uploadfile(Student s)
        {
            string filename = null;
            if (s.ImageFile != null)
            {
                string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, "images");
                filename = Guid.NewGuid().ToString() + "-" + s.ImageFile.FileName;
                string filePath = Path.Combine(uploadDir, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    s.ImageFile.CopyTo(fileStream);
                }
            }
            return filename;
        }
        public async Task<IActionResult>Delete(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var student = await _context.Student.FirstOrDefaultAsync(c => c.id == id);
            if (student == null) return NotFound();

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Edit(int? id)
        {
            if(id== null || id <= 0) return BadRequest();
            var student = await _context.Student.FirstOrDefaultAsync(c => c.id == id);
            if(student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(int id,Student student)
        {
            var s = await _context.Student.FirstOrDefaultAsync(c => c.id == id);
            s.stuid = student.stuid;
            s.stuname = student.stuname;
            s.stulastname = student.stulastname;
            s.stuaddress = student.stuaddress;
            s.stuphone = student.stuphone;
            s.GPA = student.GPA;
            if (student.stuimg != null)
            {
                string filepath = Path.Combine(_hostEnvironment.WebRootPath, "images", student.stuname);
                System.IO.File.Delete(filepath);

            }
       
            s.stuimg = Uploadfile(student);
            _context.Update(s);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit));
            //return View(student);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var student = await _context.Student.FirstOrDefaultAsync(c => c.id == id);
            if (student == null) return NotFound();
            return View(student);
        }
    }
}
