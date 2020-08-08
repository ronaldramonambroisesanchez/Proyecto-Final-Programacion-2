using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API1.Entities;
using API1.Entities.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

        public class DistribuidoresController : ControllerBase
        {
            private readonly AppDBContext context;

            public DistribuidoresController(AppDBContext context)
            {
                this.context = context;
            }

        // GET: api/<DistribuidoresController>
        [HttpGet]
            public IEnumerable<Distribuidores> Get()
            {
                return context.Distribuidores.ToList();
            }

        // GET api/<DistribuidoresController>/5
        [HttpGet("{id}")]
            public Distribuidores Get(string id)
            {
                var distribuidores = context.Distribuidores.FirstOrDefault(p => p.CodigoProd == id);
                return distribuidores;
            }

        // POST api/<DistribuidoresController>
        [HttpPost]
            public ActionResult Post([FromBody] Distribuidores distribuidores)
            {
                try
                {
                    context.Distribuidores.Add(distribuidores);
                    context.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

            }

        // PUT api/<DistribuidoresController>/5
        [HttpPut("{id}")]
            public ActionResult Put(String id, [FromBody] Distribuidores distribuidores)
            {
                if (distribuidores.CodigoProd == id)
                {
                    context.Entry(distribuidores).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

        // DELETE api/<DistribuidoresController>/5
        [HttpDelete("{id}")]
            public ActionResult Delete(string id)
            {
                var distribuidores = context.Distribuidores.FirstOrDefault(p => p.CodigoProd == id);
                if (distribuidores != null)
                {
                    context.Distribuidores.Remove(distribuidores);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
