using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_1.Models;

namespace WebAPI_1.Data
{
    public interface IEventRepository : IGenericRepository
    {
        Task<IEnumerable<EventModel>> GetEvents();
        Task<EventModel> GetEvent(int id);
    }
}