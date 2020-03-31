using Mo = Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IRepository
    {
        public DbSet<Mo.City> Cities { get; set; }
        public DbSet<Mo.Company> Companies { get; set; }
        public DbSet<Mo.Contact> Contacts { get; set; }
        public DbSet<Mo.Phone> Phones { get; set; }
        public DbSet<Mo.PhoneType> PhoneTypes { get; set; }
        public DbSet<Mo.State> States { get; set; }
        Task<int> SaveChangesAsync();
    }
}
