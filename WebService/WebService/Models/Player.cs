using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public string NomePokemonPreferido { get; set; }
        public int NumeroPokemon { get; set; }
        public string UrlFotoPokemon { get; set; }
    }
}
