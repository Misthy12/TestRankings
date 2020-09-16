using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestRanking.Data;
using TestRanking.Models;

namespace TestRanking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Tiendas = await _context.TblTiendas.Include(x => x.TblPuntos).ToListAsync();
            ViewBag.Puntos = await _context.TblPuntos.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(int IdTienda)
        {
            TblPuntos votos = new TblPuntos();
            votos.Puntos++;
            votos.Total += votos.Puntos;
            votos.IdTienda = IdTienda;
            _context.Add(votos);
            await _context.SaveChangesAsync();
             ViewBag.Puntos = await _context.TblPuntos.ToListAsync();
            ViewBag.Tiendas = await _context.TblTiendas.Include(x=>x.TblPuntos).ToListAsync();
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
