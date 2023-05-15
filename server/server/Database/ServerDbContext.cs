using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using server.Models;

namespace server.Database
{
    public class ServerDbContext : DbContext
    {
        public DbSet<Track> Track { get; set; }
        public DbSet<Comment> Comment { get; set; }

        public ServerDbContext(DbContextOptions<ServerDbContext> options) : base(options)
        {
        }

    }
}
