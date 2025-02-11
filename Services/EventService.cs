using EventEaseApp;

namespace EventEaseApp;
public class EventService
{
    private readonly List<Event> _events;
    private int _nextId;
    private IEnumerable<Event>? _cachedEvents;

    public EventService()
    {
        _events = new List<Event>();
        _nextId = 1;
    }

    public async Task<IEnumerable<Event>> GetEventsAsync()
    {
        if (_cachedEvents == null)
        {
            // Simulate async data fetching
            await Task.Delay(100);
            _cachedEvents = _events.ToList();
        }
        return _cachedEvents;
    }

    public Event GetEventById(int id)
    {
        return _events.FirstOrDefault(e => e.Id == id);
    }

    public void AddEvent(Event newEvent)
    {
        newEvent.Id = _nextId++;
        _events.Add(newEvent);
        _cachedEvents = null; // Invalidate cache
    }

    public void UpdateEvent(Event updatedEvent)
    {
        var existingEvent = _events.FirstOrDefault(e => e.Id == updatedEvent.Id);
        if (existingEvent != null)
        {
            existingEvent.EventName = updatedEvent.EventName;
            existingEvent.Date = updatedEvent.Date;
            existingEvent.Location = updatedEvent.Location;
            _cachedEvents = null; // Invalidate cache
        }
    }

    public void DeleteEvent(int id)
    {
        var eventToDelete = _events.FirstOrDefault(e => e.Id == id);
        if (eventToDelete != null)
        {
            _events.Remove(eventToDelete);
            _cachedEvents = null; // Invalidate cache
        }
    }

    public void AddAttendee(int eventId, Attendee attendee)
    {
        var eventItem = GetEventById(eventId);
        if (eventItem != null)
        {
            eventItem.Attendees.Add(attendee);
            _cachedEvents = null; // Invalidate cache
        }
    }
}