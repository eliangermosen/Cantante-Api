using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitmoApi.Context;
using RitmoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RitmoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RitmoController : ControllerBase
    {
        private readonly AppDbContext context;

        public RitmoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<RitmoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.CANTANTES.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //try
            //{

            //}
            //catch (Exception ex)
            //{

            //}
        }

        // GET api/<RitmoController>/5
        [HttpGet("{id}", Name ="GetRitmo")]
        public ActionResult Get(int id)
        {
            try
            {
                var cantantes = context.CANTANTES.FirstOrDefault(c => c.ID == id);
                return Ok(cantantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<RitmoController>
        [HttpPost]
        public ActionResult Post([FromBody]Ritmo ritmo)
        {
            try
            {
                context.CANTANTES.Add(ritmo);
                context.SaveChanges();
                return CreatedAtRoute("GetRitmo", new { id = ritmo.ID }, ritmo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RitmoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Ritmo ritmo)
        {
            try
            {
                if (ritmo.ID == id)
                {
                    context.Entry(ritmo).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetRitmo", new { id = ritmo.ID }, ritmo);
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

        // DELETE api/<RitmoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var ritmo = context.CANTANTES.FirstOrDefault(c => c.ID == id);
                if (ritmo != null)
                {
                    context.CANTANTES.Remove(ritmo);
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
