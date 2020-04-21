using Microsoft.EntityFrameworkCore;
using SwaggerAuth.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaggerAuth.Entity
{
   public class RepoContext:DbContext
    {
        public RepoContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
