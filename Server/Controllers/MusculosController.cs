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
    [Route("api/Musculos")]
    public class MusculosController: ControllerBase
    {
        private readonly dbContext context;

        public MusculosController(dbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult <List<Musculo>>> Get()
        {
            return await context.Musculos.Include(x => x.Inserciones).ToListAsync();
        }
        [HttpPost]

        public async Task<ActionResult<Musculo>> Post(Musculo musculo)
        {
            try
            {
                context.Musculos.Add(musculo);
                await context.SaveChangesAsync();
                return musculo;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Musculo>> Get(int id)
        {
            Musculo musculo = await context.Musculos.Where(x => x.Id == id).Include(x => x.Inserciones).FirstOrDefaultAsync();
            if(musculo == null)
            {
                return NotFound($"No existe el músculo con id {id}");
            }
            return musculo;
        }
        [HttpPut("{id:int}")]

        public async Task<ActionResult<Musculo>> Put(int id, Musculo musculo)
        {
            if(musculo.Id != id)
            {
                return BadRequest("Datos Incorrectos");
            }
            Musculo muscle = await context.Musculos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(muscle == null)
            {
                return NotFound("No Existe el musculo a modificar");
            }
            muscle.CodMusculo = musculo.CodMusculo;
            muscle.NombreMusculo = musculo.NombreMusculo;

            try
            {
                context.Musculos.Update(muscle);
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
            Musculo muscle = await context.Musculos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (muscle == null)
            {
                return NotFound($"No Existe el musculo con id {id}");
            }
            try
            {
                context.Musculos.Remove(muscle);
                await context.SaveChangesAsync();
                return Ok($"El musculo{muscle.NombreMusculo} ha sido borrado");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        
        
    }
}
