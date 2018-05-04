using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FisrtName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}

