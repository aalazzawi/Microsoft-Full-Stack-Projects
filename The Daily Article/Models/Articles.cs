using System;
using System.Collections.Generic;

namespace TheDailyArticle.Models
{
    public partial class Articles
    {
        public Articles()
        {
            ArticlesType = new HashSet<ArticlesType>();
            Editors = new HashSet<Editors>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public string ArticleTypeId { get; set; }

        public ICollection<ArticlesType> ArticlesType { get; set; }
        public ICollection<Editors> Editors { get; set; }
    }
}
