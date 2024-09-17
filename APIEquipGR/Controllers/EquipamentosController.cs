using APIEquipGR.Context;
using APIEquipGR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIEquipGR.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipamentosController(AppDbContext context)
        {
            _context = context;
        }




        // GET: /equipamentos
        [HttpGet]
        public ActionResult<IEnumerable<Equipamento>> Get()
        {
            try
            {
                return _context.Equipamento.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Entre em contato com o Desenvolvedor.");
            }
        }

        //// GET: /equipamentos/{id}
        //[HttpGet("{id:int}", Name = "ObterEquipamento")]
        //public ActionResult<Equipamento> Get(int id)
        //{
        //    var equipamento = _context.Equipamento
        //        .Include(e => e.Cliente) // Inclui a navegação para Cliente, se necessário
        //        .FirstOrDefault(e => e.IMEI == id);

        //    if (equipamento == null)
        //    {
        //        return NotFound("Equipamento não encontrado...");
        //    }
        //    return Ok(equipamento);
        //}



        //// GET: /equipamentos/{id}
        //[HttpGet("{id:int}", Name = "ObterEquipamento")]
        //public ActionResult<Equipamento> Get(int id)
        //{
        //    var equipamento = _context.Equipamento
        //        .FirstOrDefault(e => e.IMEI == id);

        //    if (equipamento == null)
        //    {
        //        return NotFound("Equipamento não encontrado...");
        //    }
        //    return Ok(equipamento);
        //}




        // POST: /equipamentos
        [HttpPost]
        public ActionResult Post([FromBody] Equipamento equipamento)
        {
            if (equipamento is null)
                return BadRequest();

            _context.Equipamento.Add(equipamento);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterEquipamento",
                new { id = equipamento.IMEI }, equipamento);
        }

        //// PUT: /equipamentos/{id}
        //[HttpPut("{id:int}")]
        //public ActionResult Put(int id, Equipamento equipamento)
        //{
        //    if (id != equipamento.IMEI)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(equipamento).State = EntityState.Modified;
        //    _context.SaveChanges();

        //    return Ok(equipamento);
        //}

        //// DELETE: /equipamentos/{id}
        //[HttpDelete("{id:int}")]
        //public ActionResult Delete(int id)
        //{
        //    var equipamento = _context.Equipamento.FirstOrDefault(e => e.IMEI == id);

        //    if (equipamento == null)
        //    {
        //        return NotFound("Equipamento não localizado...");
        //    }
        //    _context.Equipamento.Remove(equipamento);
        //    _context.SaveChanges();

        //    return Ok(equipamento);
        //}
    }
}
