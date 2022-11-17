using AdvanceWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AdvanceWeb.Controllers
{
    public class CallSubjectController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        public CallSubjectController()
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

        public async Task<List<Subjects>> Getenroll()
        {
            List<Subjects> subjectlist = new List<Subjects>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7122/api/Subject"))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    subjectlist = JsonConvert.DeserializeObject<List<Subjects>>(strJson);
                }
            }
            return subjectlist;
        }
        public async Task<ActionResult> Details(int id)
        {
            Subjects subject = new Subjects();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7122/api/Subject/id?id=" + id))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    subject = JsonConvert.DeserializeObject<Subjects>(strJson);
                }
            }
            return View(subject);
        }

        // GET: CallIssueController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: CallIssueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Subjects subjectss)
        {
            try
            {
                Subjects sub = new Subjects();
                using (var httpClient = new HttpClient(_clientHandler))
                {
                    StringContent content =
                        new StringContent(JsonConvert.SerializeObject(subjectss), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:7122/api/Subject", content))
                    {
                        string strJson = await response.Content.ReadAsStringAsync();
                        sub = JsonConvert.DeserializeObject<Subjects>(strJson);
                        if (ModelState.IsValid)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                return View(sub);
            }
            catch
            {
                return View();
            }
        }

        // GET: CallIssueController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Subjects subject = new Subjects();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7122/api/Subject/id?id" + id))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    subject = JsonConvert.DeserializeObject<Subjects>(strJson);
                }
            }
            return View(subject);
        }

        // POST: CallIssueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Subjects subjectss)
        {
            Subjects sub = new Subjects();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content =
                        new StringContent(JsonConvert.SerializeObject(subjectss), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:7122/api/Subject/id?id" + id, content))
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

                using (var response = await httpClient.DeleteAsync("https://localhost:7122/api/Subject/" + id))
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
