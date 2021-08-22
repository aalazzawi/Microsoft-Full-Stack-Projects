using System;
using System.Collections.Generic;

namespace TheDailyArticle.Models
{
    public partial class Members
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
