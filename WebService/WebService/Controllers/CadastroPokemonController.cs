using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.DAL;
using WebService.Models;

namespace WebService.Controllers
{
    public class CadastroPokemonController : Controller
    {
        private readonly CadastroPokemonDAL _cadastroPokemonDAO;
        public CadastroPokemonController(CadastroPokemonDAL cadastroPokemonDAO)
        {
            _cadastroPokemonDAO = cadastroPokemonDAO;
        }

        public IActionResult Index()
        {
           ViewBag.ListPlayers = _cadastroPokemonDAO.Listar();
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
            if (!_cadastroPokemonDAO.Cadastrar(player))
            {
                ModelState.AddModelError("", "Esse player já esta cadastrado!");
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult About()
        {
            return View("About"); 
        }


    }
}
