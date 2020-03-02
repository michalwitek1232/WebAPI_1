using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_1.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public DateTime Created { get; set; }
        public DateTime Ends { get; set; }
        public string OwnerUsername { get; set; }

    }
}
