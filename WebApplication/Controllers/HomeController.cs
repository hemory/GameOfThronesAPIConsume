using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public async Task<IActionResult> Index()
        {
            
            
         var jonSnow = await DAL.GetCharacterById(583);
         var balonGreyJoy = await DAL.GetCharacterById(12);
         var walder = await DAL.GetCharacterById(2);
         var margaeryTyrell  = await DAL.GetCharacterById(16);
         var lancelLannister = await DAL.GetCharacterById(613);
         
         List<Character> characters = new List<Character>
         {
             jonSnow,balonGreyJoy,margaeryTyrell,walder,lancelLannister
         };
            
            return View(characters);
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