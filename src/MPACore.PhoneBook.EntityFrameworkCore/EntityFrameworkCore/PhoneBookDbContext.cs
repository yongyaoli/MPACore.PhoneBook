using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MPACore.PhoneBook.Authorization.Roles;
using MPACore.PhoneBook.Authorization.Users;
using MPACore.PhoneBook.MultiTenancy;
using MPACore.PhoneBook.PhoneBooks.Persons;
using MPACore.PhoneBook.PhoneBooks.PhoneNumbers;

namespace MPACore.PhoneBook.EntityFrameworkCore
{
    public class PhoneBookDbContext : AbpZeroDbContext<Tenant, Role, User, PhoneBookDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            : base(options)
        {
        }

        //在这如果你写Person 就是单数表名
        public DbSet<Person> Persons { get; set; }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }


        //重写创建实体的方法
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person", "PB");
            modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumber", "PB");


            base.OnModelCreating(modelBuilder);
        }


    }
}
