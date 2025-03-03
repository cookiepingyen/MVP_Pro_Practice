using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Models.DAO
{
    public class Emp
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Salary { get; set; }


        public Emp(int ID, string Name, string desc, string email, string phone, int salary)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = desc;
            this.Email = email;
            this.Phone = phone;
            this.Salary = salary;
        }
    }
}
