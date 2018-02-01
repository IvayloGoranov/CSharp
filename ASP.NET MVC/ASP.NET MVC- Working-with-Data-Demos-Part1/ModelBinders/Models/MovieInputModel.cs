using System;

namespace ModelBinders.Models
{
    public class MovieInputModel
    {
        public string Title { get; set; }

        public string Review { get; set; }

        public int LengthInMinutes { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}