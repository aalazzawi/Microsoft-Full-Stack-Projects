using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheDailyArticle.Models;

namespace TheDailyArticle.Data
{
    public class TheDailyArticleContext : DbContext
    {
        public TheDailyArticleContext (DbContextOptions<TheDailyArticleContext> options)
            : base(options)
        {
        }

        public DbSet<TheDailyArticle.Models.Articles> Articles { get; set; }

        public DbSet<TheDailyArticle.Models.ArticlesType> ArticlesType { get; set; }

        public DbSet<TheDailyArticle.Models.Editors> Editors { get; set; }

        public DbSet<TheDailyArticle.Models.Media> Media { get; set; }

        public DbSet<TheDailyArticle.Models.Members> Members { get; set; }
    }
}
