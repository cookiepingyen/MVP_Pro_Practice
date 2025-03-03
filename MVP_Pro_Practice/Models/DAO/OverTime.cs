using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Models.DAO
{
    internal class OverTime
    {
        public int ID { get; set; }
        public int Emp_id { get; set; }

        public double overHours { get; set; }

        public DateTime DateTime { get; set; }

        public string Reason { get; set; }


        public OverTime(int id, int emp_id, double overHours, DateTime dateTime, string reason)
        {
            this.ID = id;
            this.Emp_id = emp_id;
            this.overHours = overHours;
            this.DateTime = dateTime;
            this.Reason = reason;
        }
    }
}
