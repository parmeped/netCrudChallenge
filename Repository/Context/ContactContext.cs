using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Contracts.Repository;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public class ContactContext : DbContext, IRepository
    {        
        public ContactContext() : base() { }

        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }        

        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entities. The startValue is for the seeded data.
            modelBuilder.Entity<City>()
                .Property(x => x.ID)
                .HasIdentityOptions(startValue: 11);
            modelBuilder.Entity<Company>()
                .Property(x => x.ID)
                .HasIdentityOptions(startValue: 11);
            modelBuilder.Entity<Contact>()
                .Property(x => x.ID)
                .HasIdentityOptions(startValue: 21);
            modelBuilder.Entity<Phone>()
                .Property(x => x.ID)
                .HasIdentityOptions(startValue: 41);
            modelBuilder.Entity<PhoneType>()
                .Property(x => x.ID)
                .HasIdentityOptions(startValue: 3);
            modelBuilder.Entity<State>()
                .Property(x => x.ID)
                .HasIdentityOptions(startValue: 6);

            base.OnModelCreating(modelBuilder);

            //Data seed
            SeedDatabase(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        private void SeedDatabase(ModelBuilder m)
        {
            var sName = "Street Name";
            var rand = new Random();
            var minPhone = 11111111;
            var maxPhone = 99999999;
            var creAt = DateTime.Now;
            
            // Cities
            var i = 0;
            var j = 1;
            while (i < 10)
            {
                i++;
                var city = new City { ID = i, Name = "City " + i, StateID = j, CreatedAt = creAt, Active = true };                
                m.Entity<City>().HasData(city);
                if (i % 2 == 0)
                {
                    j++;   
                }   
            }

            // States
            i = 0;
            while (i < 5) 
            {
                i++;
                var state = new State { ID = i, Name = "State " +  i, CreatedAt = creAt, Active = true };
                m.Entity<State>().HasData(state);
            }

            i = 0;
            j = 1;
            // Companies
            while (i < 10)
            {
                i++;
                var company = new Company { ID = i, Name = "Company " + i, CityID = i, StreetName = sName, StreetNumber = (ushort)rand.Next(1, 5000), CreatedAt = creAt, Active = true };

                m.Entity<Company>().HasData(company);
            }

            // Phone types
            var type1 = new PhoneType { ID = 1, Name = "work", CreatedAt = creAt, Active = true };
            var type2 = new PhoneType { ID = 2, Name = "personal", CreatedAt = creAt, Active = true };
            m.Entity<PhoneType>().HasData(type1);
            m.Entity<PhoneType>().HasData(type2);

            // Contacts
            i = 0;
            j = 1;
            while (i < 20)
            {
                i++;
                var contact = new Contact
                {
                    ID           = i,
                    Name         = "Contact " + i,
                    CityID       = j,
                    CompanyID    = j,
                    StreetName   = sName,
                    StreetNumber = (ushort)rand.Next(1, 5000),
                    BirthDate    = randomBirthDate(rand),
                    Email        = "ContactEmail" + i + "@mail.com",
                    ProfileImage = "ImageUrl",
                    CreatedAt = creAt,
                    Active = true
                };
                if (i % 2 == 0)
                {
                    j++;
                }
                m.Entity<Contact>().HasData(contact);
            }

            // Phones
            i = 0;            
            while (i < 20)
            {
                i++;
                var phone = new Phone { ID = i, Prefix = 549.ToString(), Number = rand.Next(minPhone, maxPhone).ToString(), PhoneTypeID = 1, ContactID = i, CreatedAt = creAt, Active = true };                
                m.Entity<Phone>().HasData(phone);
            }            
            j = 0;
            while (i < 40)
            {
                i++;
                j++;
                var phone = new Phone { ID = i, Prefix = 549.ToString(), Number = rand.Next(minPhone, maxPhone).ToString(), PhoneTypeID = 2, ContactID = j, CreatedAt = creAt, Active = true };                
                m.Entity<Phone>().HasData(phone);
            }

        }

        private DateTime randomBirthDate(Random rand)
        {               
            return DateTime.Now.AddDays(rand.Next(5000, 40000) * -1);
        }
    }   

}

