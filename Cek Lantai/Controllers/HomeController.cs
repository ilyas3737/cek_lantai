using Cek_Lantai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cek_Lantai.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult GetData(int nomor)
        {
            
            int a = 0;
            int b = 0;
            int awal = 5;
            int akhir = 7;
            int lantai = 0;

            b = awal;

            for (int i = 1; i <= nomor; i++)
            {
                a++;
                if (a == 1)
                {
                    lantai += 1;
                }
                else
                if (a == b)
                {
                    a = 0;
                    if (b != akhir)
                    {
                        b += 1;
                    }
                    else
                    {
                        b = awal;
                    }
                }
            }
            return Json(lantai);
        }
    }
}