using System.Net;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private DataContext dc;
        public PessoaController(DataContext context)
        {
            this.dc = context;
        }

        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Pessoa p)
        {
            dc.pessoa.Add(p);
            await dc.SaveChangesAsync();

            return Created("Objeto pessoa", p);
        }

        [HttpGet("api")]
        public async Task<ActionResult> listar()
        {
            var dados = await dc.pessoa.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("api/{codigo}")]
        public Pessoa filtrar(int codigo)
        {
            Pessoa p = dc.pessoa.Find(codigo);
            return p;
        }

        [HttpPut("api")]
        public async Task<ActionResult> editar([FromBody] Pessoa p)
        {
            dc.pessoa.Update(p);
            await dc.SaveChangesAsync();

            return Ok(p); 
        }

        [HttpDelete("api/{codigo}")]
        public async Task<ActionResult> remover(int codigo)
        {
            Pessoa p =  filtrar(codigo);
            if (p == null)
            {
                return NotFound();
            }else
            {
                dc.pessoa.Remove(p);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }
    }
}