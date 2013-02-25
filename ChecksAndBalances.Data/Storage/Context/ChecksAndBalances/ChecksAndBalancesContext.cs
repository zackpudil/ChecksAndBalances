﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChecksAndBalances.Data.Models;

namespace ChecksAndBalances.Data.Storage.Context
{
    public class ChecksAndBalancesContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleState> ArticleStates { get; set; }
        public DbSet<CategoryTag> CategoryTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ArticleInProgress> ArticlesInProgres { get; set; }
        public DbSet<ArticleImage> ArticleImages { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

        public ChecksAndBalancesContext()
            : base("ChecksAndBalances")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(a => a.DatePublished)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Advertisement>()
                .Property(a => a.DateCreated)
                .HasColumnType("datetime2");
        }
    }
}
