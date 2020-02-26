using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_1.Data;
using WebAPI_1.Models;

namespace WebAPI_1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataCTXController : ControllerBase
    {
        private readonly DataContext _context; //pole prywatne

        public DataCTXController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var values = _context.Users.ToList();
            return Ok(values); //zwracanie
        }

        //Get id
        [AllowAnonymous]
        [HttpGet("{id}")]

        public IActionResult GetValue(int id)
        {
            var values = _context.Users.FirstOrDefault(x => x.Id == id);
            return Ok(values); //zwracanie
        }


        //dodawanie do tabeli

        [HttpPost]

        public async void AddValue([FromBody] Users user)
        {
            await _context.Users.AddAsync(user);
            _context.SaveChanges(); //z modelu

        }

        //Edycja wartości

        [HttpPut("{id}")]

        public async Task<IActionResult> EditValue(int id, [FromBody] Users user)
        {
            var data = await _context.Users.FindAsync(id);
            data.Imie = user.Imie;
            _context.Users.Update(data);
            _context.SaveChanges();
            return Ok();
        }

        //usuwanie wartości

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteValue(int id)
        {
            var data = await _context.Users.FindAsync(id);
            _context.Users.Remove(data);
            _context.SaveChanges();
            return Ok();
        }
    }
}