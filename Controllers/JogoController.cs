using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        // Lista para armazenar jogos. (Em um projeto real, isso seria um banco de dados.)
        private static List<Jogo> jogos = new List<Jogo>
        {
            new Jogo { Id = 1, Nome = "DarK Souls 3", Plataforma = "PC", Descricao = "Jogo de RPG.", DataLancamento = new DateTime(2016, 3, 24) },
            new Jogo { Id = 2, Nome = "Hollow Knight", Plataforma = "Nintendo Switch", Descricao = "Metroidvania de plataforma.", DataLancamento = new DateTime(2017, 2, 24) }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Jogo>> Get()
        {
            return Ok(jogos);
        }

         [HttpGet("{id}")]
        public ActionResult<Jogo> Get(int id)
        {
            var jogo = jogos.FirstOrDefault(j => j.Id == id);

            if (jogo == null)
            {
                return NotFound();
            }

            return Ok(jogo);
        }

         [HttpPost]
        public ActionResult<Jogo> Post([FromBody] Jogo novoJogo)
        {
            if (novoJogo == null)
            {
                return BadRequest("Jogo não pode ser nulo.");
            }

            novoJogo.Id = jogos.Max(j => j.Id) + 1; // Gerando um novo ID.
            jogos.Add(novoJogo);

            return CreatedAtAction(nameof(Get), new { id = novoJogo.Id }, novoJogo);
        }

                [HttpPut("{id}")]
        public ActionResult<Jogo> Put(int id, [FromBody] Jogo jogoAtualizado)
        {
            var jogo = jogos.FirstOrDefault(j => j.Id == id);

            if (jogo == null)
            {
                return NotFound();
            }

            jogo.Nome = jogoAtualizado.Nome;
            jogo.Plataforma = jogoAtualizado.Plataforma;
            jogo.Descricao = jogoAtualizado.Descricao;
            jogo.DataLancamento = jogoAtualizado.DataLancamento;

            return Ok(jogo);
        }

        // DELETE: api/jogos/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var jogo = jogos.FirstOrDefault(j => j.Id == id);

            if (jogo == null)
            {
                return NotFound();
            }

            jogos.Remove(jogo);

            return NoContent();
        }
    }
}