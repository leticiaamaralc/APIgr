using APIEquipGR.Context;
using APIEquipGR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIEquipGR.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LotesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /lotes
        [HttpGet]
        public ActionResult<IEnumerable<Lote>> Get()
        {
            try
            {
                return _context.Lote.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação. Entre em contato com o Desenvolvedor.");
            }
        }

        //// GET: /lotes/{id}
        //[HttpGet("{id:int}", Name = "ObterLote")]
        //public ActionResult<Lote> Get(int id)
        //{
        //    //var lote = _context.Lote.Include(l => l.Equipamentos).FirstOrDefault(l => l.ID == id);

        //    //if (lote == null)
        //    //{
        //    //    return NotFound("Lote não encontrado...");
        //    //}
        //    return Ok();
        //}

        // POST: /lotes
        [HttpPost]
        public ActionResult Post(Lote lote)
        {
            if (lote is null)
                return BadRequest();

            _context.Lote.Add(lote);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterLote",
                new { id = lote.ID }, lote);
        }

        //// PUT: /lotes/{id}
        //[HttpPut("{id:int}")]
        //public ActionResult Put(int id, Lote lote)
        //{
        //    if (id != lote.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(lote).State = EntityState.Modified;
        //    _context.SaveChanges();

        //    return Ok(lote);
        //}

        //// DELETE: /lotes/{id}
        //[HttpDelete("{id:int}")]
        //public ActionResult Delete(int id)
        //{
        //    var lote = _context.Lote.FirstOrDefault(l => l.ID == id);

        //    if (lote == null)
        //    {
        //        return NotFound("Lote não localizado...");
        //    }
        //    _context.Lote.Remove(lote);
        //    _context.SaveChanges();

        //    return Ok(lote);
        //}
    }
}
