using ApiCrudGestores.Context;
using ApiCrudGestores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCrudGestores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly AppDBContext context;
        public GestoresController(AppDBContext context)
        {
            this.context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.gestores_bd.ToList());
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetGestor")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.gestores_bd.FirstOrDefault(p => p.id== id);
                return Ok(gestor);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] GestoresBD gestor)
        {
            try
            {
                context.gestores_bd.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new {id = gestor.id}, gestor);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GestoresBD gestor)
        {
            try
            {
                if(gestor.id == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.gestores_bd.FirstOrDefault(p => p.id == id);
                if(gestor != null)
                {
                    context.gestores_bd.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
