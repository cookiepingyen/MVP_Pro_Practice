using IOCServiceCollection.Attributes;
using MVP_Pro_Practice.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Models.Repository
{
    [Singleton]
    internal class EmpRepository : IEmpRepository
    {
        public Emp GetEmpByID(int ID)
        {
            switch (ID)
            {
                case 1:
                    return new Emp(1, "Yen", "員工1號", "yen@example.com", "0912345678", 50000);
                case 2:
                    return new Emp(2, "Leo", "員工2號", "leo@example.com", "0922345678", 60000);
                case 3:
                    return new Emp(3, "Ming", "員工3號", "ming@example.com", "0932345678", 55000);
                case 4:
                    return new Emp(4, "Anna", "員工4號", "anna@example.com", "0942345678", 52000);
                case 5:
                    return new Emp(5, "John", "員工5號", "john@example.com", "0952345678", 48000);
                case 6:
                    return new Emp(6, "Lily", "員工6號", "lily@example.com", "0962345678", 53000);
                default:
                    return null;
            }
        }

        public List<Emp> GetEmpList()
        {

            return new List<Emp>()
            {
                new Emp(1, "Yen", "員工1號", "yen@example.com", "0912345678", 50000),
                new Emp(2, "Leo", "員工2號", "leo@example.com", "0922345678", 60000),
                new Emp(3, "Ming", "員工3號", "ming@example.com", "0932345678", 55000),
                new Emp(4, "Anna", "員工4號", "anna@example.com", "0942345678", 52000),
                new Emp(5, "John", "員工5號", "john@example.com", "0952345678", 48000),
                new Emp(6, "Lily", "員工6號", "lily@example.com", "0962345678", 53000)
            };
        }
    }
}
