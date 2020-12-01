using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.DAL
{
    public class CadastroPokemonDAL
    {
        private readonly Context _context;

        public CadastroPokemonDAL(Context context)
        {
            _context = context;
        }

        public List<Player> Listar()
        {
            return _context.Players.ToList();
        }


        public Player FindByName(string nome)
        {
            return _context.Players.FirstOrDefault(p => p.Nome == nome);
        }

        public Player FindById(int id)
        {
            return _context.Players.Find(id);
        }


        public bool Cadastrar(Player player)
        {
            Player playerFound = _context.Players.FirstOrDefault(p => p.Nome == player.Nome);

            if (FindByName(player.Nome) != null)
            {
                return false;
            }
            else
            {
                _context.Players.Add(player);
                _context.SaveChanges();

                return true;
            }
        }


        public bool Editar(int id, Player player)
        {

            Player playerFound = _context.Players.FirstOrDefault(p => p.Id == id);

            if (player != null)
            {
                playerFound.Nome = player.Nome;
                playerFound.Email = player.Email;
                playerFound.Idade = player.Idade;
                playerFound.NomePokemonPreferido = player.NomePokemonPreferido;
                playerFound.NumeroPokemon = player.NumeroPokemon;
                playerFound.UrlFotoPokemon = player.UrlFotoPokemon;
                _context.Players.Update(playerFound);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }   
        }

        public bool Excluir(int id)
        {
            Player playerFound = _context.Players.FirstOrDefault(p => p.Id == id);
            if (playerFound != null)
            {
                _context.Players.Remove(FindById(id));
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
                
        }


    }
}
