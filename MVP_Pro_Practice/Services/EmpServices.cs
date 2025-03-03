using IOCServiceCollection.Attributes;
using MVP_Pro_Practice.Models.DAO;
using MVP_Pro_Practice.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Services
{
    [Singleton]
    internal class EmpServices : IEmpService
    {
        private readonly IEmpRepository _empRepository;

        public EmpServices(IEmpRepository empRepository)
        {
            _empRepository = empRepository;
        }

        public Emp GetEmpByID(int id)
        {
            return _empRepository.GetEmpByID(id);
        }

        public List<Emp> GetEmpList()
        {
            return _empRepository.GetEmpList();
        }
    }
}
