using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_1.Data;
using WebAPI_1.DTOs;
using WebAPI_1.Models;

namespace WebAPI_1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private DataContext _context;

        public EventsController(IEventRepository repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var events = await _repo.GetEvents();

            //var usersToReturn = _mapper.Map<IEnumerable<UserForListDTO>>(events);

            return Ok(events);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var eventOne = await _repo.GetEvent(id) ;

            //var userToReturn = _mapper.Map<UserForDetailsDto>(user);

            return Ok(eventOne);
        }

        //usuwanie eventów

        [Authorize]
        [HttpDelete("{event_id}")]

        public async Task<IActionResult> DeleteValue(int event_id)
        {
            var data = await _context.Eventmodels.FindAsync(event_id);
            _context.Eventmodels.Remove(data);
            _context.SaveChanges();
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteValues()
        {
            List<EventModel> data = (List < EventModel >) await _repo.GetEvents();

            foreach (var i in data)
            {
                _repo.Delete(i);                
            }
            _repo.SaveAll();
            
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> AddEvent(EventToCreateDto eventToCreateDto )
        {
            var eventToCreate = new EventModel
            {
                Nazwa = eventToCreateDto.Nazwa,
                Opis = eventToCreateDto.Opis,
                OwnerUsername = eventToCreateDto.OwnerUsername,
                Created = System.DateTime.Now,
                Ends = eventToCreateDto.Ends
            };

            await _context.AddAsync(eventToCreate);
            _repo.Add<EventModel>(eventToCreate);
            await _context.SaveChangesAsync();
            await _repo.SaveAll();

            return Ok();
        }

    }
}