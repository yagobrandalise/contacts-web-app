using ContactsApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApplication.Context
{
    public class ContactsDbContext : DbContext
    {
        private readonly ContactsDbContext _context;
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }

    }
}
