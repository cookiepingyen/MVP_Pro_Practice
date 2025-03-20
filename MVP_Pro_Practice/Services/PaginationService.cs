using IOCServiceCollection.Attributes;
using MVP_Pro_Practice.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Services
{
    [Singleton("IPaginationService")]
    internal class PaginationService : IPaginationService
    {
        private readonly IPaginationRepository _paginationrepository;

        public PaginationService(IPaginationRepository paginationRepository)
        {
            this._paginationrepository = paginationRepository;
        }
        public int GetTotalPageNum()
        {
            return _paginationrepository.GetTotalPageNum();
        }
    }
}
