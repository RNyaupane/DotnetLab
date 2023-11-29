using Microsoft.EntityFrameworkCore;
using PortfolioWebApi.Models;

namespace PortfolioWebApi.Data
{
    public class ContactAPIDbContext : DbContext
    {
        public ContactAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
