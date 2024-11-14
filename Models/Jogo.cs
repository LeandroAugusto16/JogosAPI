using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Jogo
    {
         public int Id { get; set; }
        public string Nome { get; set; }
        public string Plataforma { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}