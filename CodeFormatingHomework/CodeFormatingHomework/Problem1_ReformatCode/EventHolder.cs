namespace Problem1_ReformatCode
{
    using System;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private readonly OrderedBag<Event> _eventsByDate = new OrderedBag<Event>();

        private readonly MultiDictionary<string, Event> _eventsByTitle = new MultiDictionary<string, Event>(true);

        public void AddEvent(DateTime date, string title, string location)
        {
            var newEvent = new Event(date, title, location);
            this._eventsByTitle.Add(newEvent.Title.ToLower(), newEvent);
            this._eventsByDate.Add(newEvent);
            Messages.PrintEventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            var title = titleToDelete.ToLower();
            var removed = 0;
            foreach (var eventToRemove in this._eventsByTitle[title])
            {
                removed++;
                this._eventsByDate.Remove(eventToRemove);
            }

            this._eventsByTitle.Remove(title);
            Messages.PrintEventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            var eventsToShow = this._eventsByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            var showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }
                
                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.PrintNoEventsFound();
            }
        }
    }
}