using Microsoft.EntityFrameworkCore;
using bookrental.core.Entities;
using bookrental.infrastructure.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientBlackList> ClientBlackList { get; set; }

        public DbSet<BookCopy> BookCopies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LoanConfiguration());
            builder.ApplyConfiguration(new LoanDetailConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new ClientBlackListConfiguration());
        }
    }
}
