namespace Problem1_ReformatCode
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }
        
        public string Location { get; set; }

        /// <summary>
        /// Compares this event to another event.
        /// </summary>
        /// <returns>
        /// Values: 0, 1, or -1.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// otherEvent;OtherEvent cannot be null.
        /// </exception>
        public int CompareTo(object obj)
        {
            Event otherEvent = obj as Event;
            if (otherEvent == null)
            {
                throw new ArgumentNullException("obj", "The object of type Event cannot be null.");
            }

            int comparedByDate = this.Date.CompareTo(otherEvent.Date);
            int comparedByTitle = string.Compare(this.Title, otherEvent.Title, StringComparison.Ordinal);
            int comparedByLocation = string.Compare(this.Location, otherEvent.Location, StringComparison.Ordinal);

            if (comparedByDate == 0)
            {
                return comparedByTitle == 0 ? comparedByLocation : comparedByTitle;
            }
            else
            {
                return comparedByDate;
            }
        }

        /// <summary>
        ///     Overides the Object's ToString() and returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            output.Append(" | " + this.Title);

            if (!string.IsNullOrEmpty(this.Location))
            {
                output.Append(" | " + this.Location);
            }

            return output.ToString();
        }
    }
}