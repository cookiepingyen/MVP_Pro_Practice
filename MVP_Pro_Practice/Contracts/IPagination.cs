using MVP_Pro_Practice.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Contracts
{
    interface IPaginationView
    {
        void PaginationResponse(int totalPageNum);
        int Total { get; set; }
        void GeneratePages(List<int> pageNumbers);
    }

    public interface IPaginationPresenter
    {
        int currentPage { get; set; }
        int TotalPageNum { get; set; }

        int ChangePage(PageType previous);
        List<int> GeneratePageNumbers(PageType init);
        void InitPageCount(int total);
        void JumpPage(int v);
    }
}
