using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoryController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            return Ok(_context.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            var value= _context.Categories.Find(id);
            if(value==null) return NotFound();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            _context.Add(p);
            _context.SaveChanges();
            return Created("", p);
        }
        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            var value = _context.Categories.Find(id);
            if (value == null) return NotFound();
            _context.Remove(value);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut]
        public IActionResult CategoryUpdate(Category p)
        {
            var value = _context.Categories.Find(p.CategoryID);
            if (value == null) return NotFound();
            value.CategoryName = p.CategoryName;
            _context.Update(value);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
