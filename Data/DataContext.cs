using Asparagus2.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Asparagus2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Call> Calls { get; set; }
    }

}
