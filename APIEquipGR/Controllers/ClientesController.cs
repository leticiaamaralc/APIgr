using APIEquipGR.Context;
using APIEquipGR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIEquipGR.Controllers
{
   
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }



        // GET: /clientes
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            try
            {
                return _context.Cliente.AsNoTracking().ToList(); // Acessa a tabela Cliente e retorna os valores
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Entre em contato com o Desenvolvedor.");
            }
        }



        //// GET: /clientes/{id}
        //[HttpGet("{id:int}", Name = "ObterCliente")]
        //public ActionResult<Cliente> Get(int id)
        //{
        //    var cliente = _context.Cliente.FirstOrDefault(p => p.ID == id);

        //    if (cliente == null)
        //    {
        //        return NotFound("Cliente não encontrado...");
        //    }
        //    return Ok(cliente);
        //}




        // POST: /clientes
        [HttpPost]
        public ActionResult Post([FromBody]Cliente cliente)
        {
            if (cliente is null)
                return BadRequest();

            _context.Cliente.Add(cliente);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCliente",
                new { id = cliente.ID }, cliente);
        }




        //// PUT: /clientes/{id}
        //[HttpPut("{id:int}")]
        //public ActionResult Put(int id, Cliente cliente)
        //{
        //    if (id != cliente.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cliente).State = EntityState.Modified;
        //    _context.SaveChanges();

        //    return Ok(cliente);
        //}




        //// DELETE: /clientes/{id}
        //[HttpDelete("{id:int}")]
        //public ActionResult Delete(int id)
        //{
        //    var cliente = _context.Cliente.FirstOrDefault(p => p.ID == id);

        //    if (cliente == null)
        //    {
        //        return NotFound("Cliente não localizado...");
        //    }
        //    _context.Cliente.Remove(cliente);
        //    _context.SaveChanges();

        //    return Ok(cliente);
        //}
    }
}

