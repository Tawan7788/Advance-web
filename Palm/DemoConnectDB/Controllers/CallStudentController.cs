using AdvanceWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AdvanceWeb.Controllers
{
    public class CallStudentController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        public CallStudentController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        // GET: CallIssueController
        public async Task<ActionResult> Index()
        {
            var enroll = await Getenroll();
            return View(enroll);
        }
        [HttpGet]

        public async Task<List<Students>> Getenroll()
        {
            List<Students> studentlist = new List<Students>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7122/api/Student"))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    studentlist = JsonConvert.DeserializeObject<List<Students>>(strJson);
                }
            }
            return studentlist;
        }
        public async Task<ActionResult> Details(int id)
        {
            Enrolls enroll = new Enrolls();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7122/api/Enroll/id?id=" + id))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    enroll = JsonConvert.DeserializeObject<Enrolls>(strJson);
                }
            }
            return View(enroll);
        }

        // GET: CallIssueController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: CallIssueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Students student)
        {
            try
            {
                Students st = new Students();
                using (var httpClient = new HttpClient(_clientHandler))
                {
                    StringContent content =
                        new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:7122/api/Student", content))
                    {
                        string strJson = await response.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<Students>(strJson);
                        if (ModelState.IsValid)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                return View(st);
            }
            catch
            {
                return View();
            }
        }

        // GET: CallIssueController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Students student = new Students();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7122/api/Student/id?id" + id))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Students>(strJson);
                }
            }
            return View(student);
        }

        // POST: CallIssueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Students student)
        {
            Students st = new Students();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content =
                        new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:7122/api/Student/id?id" + id, content))
                {

                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CallIssueController/Delete/5
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
