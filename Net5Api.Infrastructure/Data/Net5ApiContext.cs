using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Net5Api.Core.Entities;
using Net5Api.Infrastructure.Data.Configurations;

#nullable disable

namespace Net5Api.Infrastructure.Data
{
    public partial class Net5ApiContext : DbContext
    {
        public Net5ApiContext()
        {
        }

        public Net5ApiContext(DbContextOptions<Net5ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentConfiguration());

            modelBuilder.ApplyConfiguration(new PostConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
