using System;
using LiveScore.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveScore.Admin.Data
{
    public class AdminContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }

        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {

        }
    }
}
