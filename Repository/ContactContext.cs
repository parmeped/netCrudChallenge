using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository
{
    public class ContactContext : DbContext
    {
        public DbSet<City> Cities { get; set; } 
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<State> States { get; set; }

        public ContactContext() : base() { }

        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entities
            modelBuilder.Entity<City>();
            modelBuilder.Entity<Company>();
            modelBuilder.Entity<Contact>();
            modelBuilder.Entity<Phone>();
            modelBuilder.Entity<PhoneType>();
            modelBuilder.Entity<State>();            

            //Data seed
            SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder m)
        {
            var sName = "Street Name";
            var rand = new Random();
            var minPhone = 11111111;
            var maxPhone = 99999999;
            
            // Cities
            var i = 0;
            var j = 1;
            while (i < 10)
            {
                i++;
                var city = new City { ID = (uint)i, Name = "City " + i, StateID = (uint)j };
                m.Entity<City>().HasData(city);
                if (j % 2 == 0)
                {
                    j++;   
                }   
            }

            // States
            i = 0;
            while (i < 5) 
            {
                i++;
                var state = new State { ID = (uint)i, Name = "State " +  i };
                m.Entity<State>().HasData(state);
            }

            i = 0;
            j = 1;
            // Companies
            while (i < 10)
            {
                i++;
                var company = new Company { ID = (uint)i, Name = "Company " + i, CityID = (uint)i, StreetName = sName, StreetNumber = (ushort)rand.Next(1, 5000) };
                m.Entity<Company>().HasData(company);
            }

            // Phone types
            var type1 = new PhoneType { ID = (uint)1, Name = "work" };
            var type2 = new PhoneType { ID = (uint)2, Name = "personal" };
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
                    ID           = (uint)i,
                    Name         = "Contact " + i,
                    CityID       = (uint)j,
                    CompanyID    = (uint)j,
                    StreetName   = sName,
                    StreetNumber = (ushort)rand.Next(1, 5000),
                    BirthDate    = randomBirthDate(rand),
                    Email        = "ContactEmail" + i + "@mail.com",
                    ProfileImage = "ImageUrl"
                };
                if (j % 2 == 0)
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
                var phone = new Phone { ID = (uint)i, Prefix = 549.ToString(), Number = rand.Next(minPhone, maxPhone).ToString(), PhoneTypeID = 1, ContactID = (uint)i };                
                m.Entity<Phone>().HasData(phone);
            }
            i = 0;            
            while (i < 20)
            {
                i++;
                var phone = new Phone { ID = (uint)i, Prefix = 549.ToString(), Number = rand.Next(minPhone, maxPhone).ToString(), PhoneTypeID = 2, ContactID = (uint)i };                
                m.Entity<Phone>().HasData(phone);
            }

        }

        private DateTime randomBirthDate(Random rand)
        {               
            return DateTime.Now.AddDays(rand.Next(5000, 40000) * -1);
        }
    }   

}

