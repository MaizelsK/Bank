using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Entities
{
    public class BankContext : DbContext
    {
        public BankContext() : base("BankDb")
        {
            Database.SetInitializer(new BankInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }

    public class BankInitializer : CreateDatabaseIfNotExists<BankContext>
    {
        protected override void Seed(BankContext context)
        {
            User newUser = new User
            {
                Id = Guid.NewGuid(),
                FisrtName = "Kirill",
                MiddleName = "Igorevich",
                SurName = "Maizels",
                Email = "domo.ddr@gmail.com",
                BirthDate = new DateTime(1997, 11, 21),
                RegisterDate = DateTime.Now,
                Login = "maizels.k",
                Password = "123456",
                PhoneNumber = "87022828436",
                IsDeleted = false,
                Accounts = new List<Account>
                {
                    new Account
                    {
                        Id = Guid.NewGuid(),
                        Name = "Счет 1",
                        Balance = 10000,
                        CreatedDate = DateTime.Now
                    }
                }
            };

            context.Users.Add(newUser);

            base.Seed(context);
        }
    }
}
