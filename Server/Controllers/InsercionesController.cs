using Anatomia.Comunes.Data;
using Anatomia.Comunes.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anatomia.Server.Controllers
{
    [ApiController]
    [Route("api/Inserciones")]
    public class InsercionesController: ControllerBase
    {
        private readonly dbContext context;

        public InsercionesController(dbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Insercion>>> Get()
        {
            return await context.Inserciones.Include(x => x.Musculo).ToListAsync();
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Insercion>> Get(int id)
        {
            Insercion insertion = await context.Inserciones.Where(x => x.Id == id).Include(x => x.Musculo).FirstOrDefaultAsync();
            if (insertion == null)
            {
                return NotFound($"No existe la insercion con id {id}");
            }
            return Ok(insertion);
        }

        [HttpPost]

        public async Task<ActionResult<Insercion>> Post(Insercion insercion)
        {
            try
            {
                context.Inserciones.Add(insercion);
                await context.SaveChangesAsync();
                return insercion;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult<Insercion>> Put(int id, Insercion insercion)
        {
            if (insercion.Id != id)
            {
                return BadRequest("Datos Incorrectos");
            }
            Insercion insertion = await context.Inserciones.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (insertion == null)
            {
                return NotFound("No Existe la insercion a modificar");
            }
            insertion.CodInsercion = insercion.CodInsercion;
            insertion.NombreInsercion = insercion.NombreInsercion;
            insertion.MusculoId = insercion.MusculoId;

            try
            {
                context.Inserciones.Update(insertion);
                await context.SaveChangesAsync();
                return Ok("Los datos han sido cambiados");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            Insercion insertion = await context.Inserciones.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (insertion == null)
            {
                return NotFound($"No Existe la insercion con id {id}");
            }
            try
            {
                context.Inserciones.Remove(insertion);
                await context.SaveChangesAsync();
                return Ok($"La insercion {insertion.NombreInsercion} ha sido borrado");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
