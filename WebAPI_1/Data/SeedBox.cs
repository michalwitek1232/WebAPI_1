using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_1.Data;
using WebAPI_1.Models;

namespace WebAPI_1.Models
{
    public class SeedBox
    {
        private readonly DataContext _context;

        public SeedBox(DataContext context)
        {
            this._context = context;
        }

        public void SeedEvents()
        {
            var eventData = File.ReadAllText("./Data/EventSeedData.json");
            var eventsSerialized = JsonConvert.DeserializeObject<List <EventModel> >(eventData);

            foreach (var events in eventsSerialized )
            {
                _context.Add(events);
            }

            _context.SaveChanges();
        }
    }
}
