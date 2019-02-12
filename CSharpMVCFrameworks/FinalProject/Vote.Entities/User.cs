using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Vote.Entities
{
    public class User : IdentityUser
    {
        public DateTime CreatedOn { get; set; }

        public DateTime LoggedOn { get; set; }

        public string Organization { get; set; }

        public string Language { get; set; }

        public bool AnalyticalCookiesAllowed { get; set; }

        public bool NewsletterSubscription { get; set; }

        public List<Event> CreatedEvents { get; set; }

        public List<Event> ParticipatedEvents { get; set; }
    }
}
