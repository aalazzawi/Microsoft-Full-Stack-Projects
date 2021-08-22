using System;
using System.Collections.Generic;

namespace TheDailyArticle.Models
{
    public partial class Media
    {
        public int Id { get; set; }
        public byte[] Photos { get; set; }
        public string PhotoDescription { get; set; }
        public int? ArticlesId { get; set; }
    }
}
