using System;
using System.Collections.Generic;

namespace TheDailyArticle.Models
{
    public partial class ArticlesType
    {
        public int Id { get; set; }
        public string ArticleType { get; set; }
        public int? ArticlesId { get; set; }

        public Articles Articles { get; set; }
    }
}
