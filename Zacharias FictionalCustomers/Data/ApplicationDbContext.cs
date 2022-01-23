using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zacharias_FictionalCustomers.Models;

namespace Zacharias_FictionalCustomers.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Zacharias_FictionalCustomers.Models.Employee> Employee { get; set; }

        public DbSet<Zacharias_FictionalCustomers.Models.AssignedProject> AssignedProject { get; set; }
    }
}
