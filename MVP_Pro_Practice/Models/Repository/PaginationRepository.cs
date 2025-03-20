using IOCServiceCollection.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Models.Repository
{
    [Singleton("IPaginationRepository")]
    internal class PaginationRepository : IPaginationRepository
    {
        public int GetTotalPageNum()
        {
            return 300;
        }
    }
}
