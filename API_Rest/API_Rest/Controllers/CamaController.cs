using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Rest.Models;
using System.Collections.Generic;
using API_Rest.Data;

namespace DetailTEC_API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class CamaController : ControllerBase
{
   private readonly ApplicationDbContext _context;
   
   
   public CamaController(ApplicationDbContext context)
   {
       _context = context;
   }
    
    // GET: api/cama
[HttpGet]
public IEnumerable<Cama> Get()
{
    return _context.Cama.ToList();
}

[HttpPost]
public ActionResult Post([FromBody] int cantidad)
{
    try
    {
        var cama = _context.Cama.FirstOrDefault();
        if (cama == null)
        {
            cama = new Cama();
            _context.Cama.Add(cama);
        }
        cama.Cantidad += cantidad;
        _context.SaveChanges();
        return Ok();
    }
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
}
}



