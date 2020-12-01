using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.DAL;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroPokemonApiController : ControllerBase
    {
        private List<Player> listaPlayers = new List<Player> { };

        private readonly CadastroPokemonDAL _cadastroPokemonDAO;

        public CadastroPokemonApiController(CadastroPokemonDAL cadastroPokemonDAO)
        {
            _cadastroPokemonDAO = cadastroPokemonDAO;   
        }

        //POST: /api/CadastroPokemonApi/Cadastrar
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Criar(Player player)
        {

            if (!_cadastroPokemonDAO.Cadastrar(player))
            {
                return BadRequest();
            }
            else
            {
                return Created("", player);
            }

            
        }

        //PUT: /api/CadastroPokemonApi/Editar/id
        [HttpPut]
        [Route("Editar/{id}")]
        public IActionResult Editar(int id, Player player)
        {
           

            if (!_cadastroPokemonDAO.Editar(id, player))
            {
                return BadRequest();
            }
            else
            {
                Player playerEdited = _cadastroPokemonDAO.FindById(id);
                return Created("", playerEdited);
            }



           
        }

        //GET: /api/CadastroPokemonApi/LocalizarPorNome/nome
        [HttpGet]
        [Route("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            if(id != null)
            {
                if(_cadastroPokemonDAO.Excluir(id))
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                    
                }

            }
            else
            {
                return BadRequest();
            }
            

            
        }

        //GET: /api/CadastroPokemonApi/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            listaPlayers = _cadastroPokemonDAO.Listar();
            if (listaPlayers.Count() != 0)
            {
                return Ok(listaPlayers);
            }
            else
            {
                return BadRequest();
            }

        }

        //GET: /api/CadastroPokemonApi/LocalizarPorNome/nome
        [HttpGet]
        [Route("LocalizarPorNome/{nome}")]
        public IActionResult LocalizarPorNome(string nome)
        {
            Player player = _cadastroPokemonDAO.FindByName(nome);

            if(player != null)
            {
                return Ok(player);
            }
            else
            {
                return BadRequest();
            }

            
        }


    }
}
