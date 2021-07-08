using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Globalization;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //inicio de teste de aplicação
            HtmlWeb web = new HtmlWeb(); 
            HtmlDocument doc = web.Load("https://www.worten.pt/gaming/nintendo-switch/jogos-nintendo-switch");
            var HeaderNames = doc.DocumentNode.SelectNodes("//span[@class='toctext']");

            var titles = new List<Row>(); 
            foreach (var item in HeaderNames) 
            { titles.Add(new Row { Title = item.InnerText }); }
            using (var writer = new StreamWriter("C:/Users/ec2vo9113/source/repos/WebApplication1/WebApplication1/Controllers/cvs/example.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) { csv.WriteRecords(titles); }
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
    }
}
