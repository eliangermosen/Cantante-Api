using CantanteApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CantanteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CantanteController : ControllerBase
    {
        //[HttpGet]
        //public IEnumerable<Models.Cantante> Get()
        //{
        //    using (var db = new Models.CantantesContext())
        //    {
        //        IEnumerable<Models.Cantante> cantante = db.Cantantes.ToList();
        //        return cantante;
        //    }
        //}

        private readonly CantantesContext context;

        public CantanteController(CantantesContext context)
        {
            this.context = context;
        }

        // GET: api/<CantanteController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Cantantes.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CantanteController>/5
        [HttpGet("{id}", Name = "GetCantante")]
        public ActionResult Get(int id)
        {
            try
            {
                var cantantes = context.Cantantes.FirstOrDefault(c => c.Id == id);
                return Ok(cantantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CantanteController>
        [HttpPost]
        public ActionResult Post([FromBody] Cantante cantante)
        {
            try
            {
                context.Cantantes.Add(cantante);
                context.SaveChanges();
                return CreatedAtRoute("GetCantante", new { id = cantante.Id }, cantante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CantanteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cantante cantante)
        {
            try
            {
                if (cantante.Id == id)
                {
                    context.Entry(cantante).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCantante", new { id = cantante.Id }, cantante);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CantanteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var cantante = context.Cantantes.FirstOrDefault(c => c.Id == id);
                if (cantante != null)
                {
                    context.Cantantes.Remove(cantante);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
