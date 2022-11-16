using AdvanceWeb.Data;
using AdvanceWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdvanceWeb.Controllers
{
    public class StudentController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        public StudentController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
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

        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var student = await _context.Student.FirstOrDefaultAsync(c => c.id == id);
            if (student == null) return NotFound();
            return View(student);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Student student)
        {

            /*if (id == null || id <= 0) return BadRequest();
            var student = await _context.Student.FirstOrDefaultAsync(c => c.id == id);
            if (student == null) return NotFound();

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            var s = await _context.Student.FirstOrDefaultAsync(c => c.id == id);
            s.stuid = student.stuid;
            s.stuname = student.stuname;
            s.stulastname = student.stulastname;
            s.stuaddress = student.stuaddress;
            s.stuphone = student.stuphone;
            s.stuimg = student.stuimg;
            s.GPA = student.GPA;

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/
        public async Task<ActionResult> Delete(int id)
        {
            string del = "";
            using (var httpClient = new HttpClient(_clientHandler))
            {

                using (var response = await httpClient.DeleteAsync("https://localhost:7122/api/Student/" + id))
                {
                    del = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: CallIssueController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
