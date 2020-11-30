using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Controllers
{
    public class CadastroPokemonController : Controller
    {
        private readonly Context _context;
        public CadastroPokemonController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           ViewBag.ListPlayers = _context.Players.ToList();
            return View();
        }

        public IActionResult PokemonCadastro(Player playerPoke)
        {
            return View("Cadastrar");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
