using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_1.Data;
using WebAPI_1.Models;

namespace WebAPI_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataCTXController : ControllerBase
    {
        private DataContext _context; //pole prywatne

        public DataCTXController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<string>> Get()
        {
            var values = _context.Users.ToList();
            return Ok(values); //zwracanie
        }

        [HttpGet("{id}")]

        public IActionResult GetValue(int id)
        {
            var values = _context.Users.FirstOrDefault(x => x.id == id);
            return Ok(values); //zwracanie
        }

        //dodawanie do tabeli

        [HttpPost]

        public void AddValue([FromBody] Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges(); //z modelu

        }

        //Edycja wartości

        [HttpPut("{id}")]

        public IActionResult EditValue(int id, [FromBody] Users user)
        {
            var data = _context.Users.Find(id);
            data.Imie = user.Imie;
            _context.Users.Update(data);
            _context.SaveChanges();
            return Ok();
        }

        //usuwanie wartości

        [HttpDelete("{id}")]

        public IActionResult DeleteValue(int id)
        {
            var data = _context.Users.Find(id);
            _context.Users.Remove(data);
            _context.SaveChanges();
            return Ok();
        }
    }
}