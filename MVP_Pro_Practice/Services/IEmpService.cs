using MVP_Pro_Practice.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Services
{
    public interface IEmpService
    {
        Emp GetEmpByID(int id);
        List<Emp> GetEmpList();

    }
}
