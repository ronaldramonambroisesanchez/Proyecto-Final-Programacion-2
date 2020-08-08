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
    public class ProductosController : ControllerBase
    {
        private readonly AppDBContext context;

        public ProductosController(AppDBContext context)
        {
            this.context = context;
        }

        // GET: api/<ProductosController>
        [HttpGet]
        public IEnumerable<Productos> Get()
        {
            return context.Productos.ToList();
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public Productos Get(string id)
        {
            var producto = context.Productos.FirstOrDefault(p=> p.CodigoProd==id);
            return producto;
        }

        // POST api/<ProductosController>
        [HttpPost]
        public ActionResult Post([FromBody] Productos productos)
        {
            try {
                context.Productos.Add(productos);
                context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(String id, [FromBody] Productos productos)
        {
            if (productos.CodigoProd == id)
            {
                context.Entry(productos).State=EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var productos = context.Productos.FirstOrDefault(p => p.CodigoProd == id);
            if (productos != null)
            {
                context.Productos.Remove(productos);
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
