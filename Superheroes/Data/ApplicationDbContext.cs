using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Superheroes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superheroes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Superhero> Superheroes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
