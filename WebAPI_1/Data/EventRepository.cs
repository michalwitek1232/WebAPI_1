using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_1.Models;

namespace WebAPI_1.Data
{
    public class EventRepository : GenericRepository, IEventRepository
    {
        private DataContext _context;

        public EventRepository(DataContext context): base(context)
        {
            _context = context;
        }

        public async Task<EventModel> GetEvent(int id)
        {
            var eventObj = await _context.Eventmodels.FirstOrDefaultAsync(u => u.Id == id);
            return eventObj;
        }

        public async Task<IEnumerable<EventModel>> GetEvents()
        {
            var events = await _context.Eventmodels.ToListAsync();
            return events;
        }
    }
}