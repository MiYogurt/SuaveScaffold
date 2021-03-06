﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Model
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source="+ Path.GetFullPath("../../") + @"blogging.db");
        }
    }

    public static class Utils {
        public static Blog getBlog()
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Single(b => b.BlogId == 1);
            }
        }

        public static void insertBlog(string Url)
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog { Url = Url });
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
