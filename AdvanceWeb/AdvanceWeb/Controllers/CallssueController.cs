using AdvanceWeb.Models;
using DemoWebAPIforstd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AdvanceWeb.Controllers
{
    public class CallIssueController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        public CallIssueController()
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

        public async Task<List<Enroll>> Getenroll()
        {
            List<Enroll> enrollList = new List<Enroll>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7122/api/Enroll"))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    enrollList = JsonConvert.DeserializeObject<List<Enroll>>(strJson);
                }
            }
            return enrollList;
        }
        public async Task<ActionResult> Details(int id)
        {
            Enroll enroll = new Enroll();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7122/api/Enroll/id?id=" + id))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    enroll = JsonConvert.DeserializeObject<Enroll>(strJson);
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
        public async Task<ActionResult> Create(Enroll enroll)
        {
            try
            {
                Enroll en = new Enroll();
                using (var httpClient = new HttpClient(_clientHandler))
                {
                    StringContent content =
                        new StringContent(JsonConvert.SerializeObject(enroll), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:7122/api/Enroll", content))
                    {
                        string strJson = await response.Content.ReadAsStringAsync();
                        en = JsonConvert.DeserializeObject<Enroll>(strJson);
                        if (ModelState.IsValid)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                return View(en);
            }
            catch
            {
                return View();
            }

        }

    }
}
