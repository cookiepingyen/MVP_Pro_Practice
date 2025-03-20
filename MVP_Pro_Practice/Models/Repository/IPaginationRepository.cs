using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Models.Repository
{
    public interface IPaginationRepository
    {
        int GetTotalPageNum();
    }
}
