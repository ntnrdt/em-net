using System;
using System.Collections.Generic;
using MeetApp.Data.Entities;

namespace MeetApp.Data.Interfaces
{
    public interface IEventService
    {
        List<Event> Get();
        Event Get(int? id);
        void Update(Event model);
        void Create(Event model);
        void Delete(int? id);
    }
}