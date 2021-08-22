using System;
using System.Collections.Generic;

namespace TheDailyArticle.Models
{
    public partial class Editors
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string EmailAddress { get; set; }
        public int? ArticlesId { get; set; }

        public Articles Articles { get; set; }
    }
}
