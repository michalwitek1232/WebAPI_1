using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_1.Models;

namespace WebAPI_1.DTOs
{
    public class EventToCreateDto
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public DateTime Created { get; set; }
        public DateTime Ends { get; set; }
        public string OwnerUsername { get; set; }
    }
}
