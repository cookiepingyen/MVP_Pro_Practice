using IOCServiceCollection.Attributes;
using MVP_Pro_Practice.Components.Pagy;
using MVP_Pro_Practice.Contracts;
using MVP_Pro_Practice.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_Pro_Practice.Presenter
{
    [Singleton("IPaginationPresenter")]
    internal class PaginationPresenter : IPaginationPresenter
    {
        IPaginationView paginationView;
        int maxPage; //總頁數
        const int PAGE_COUNT = 6; //每頁圖片筆數
        internal int _currentPage = 1;

        int total = 0; //總筆數

        int IPaginationPresenter.currentPage { get => _currentPage; set => _currentPage = value; }
        int IPaginationPresenter.TotalPageNum
        {
            get => total;
            set
            {
                total = value;
                InitPageCount(total);
            }
        }

        public PaginationPresenter(IPaginationView paginationView)
        {
            this.paginationView = paginationView;
        }

        public void InitPageCount(int totalCount)
        {
            maxPage = totalCount / PAGE_COUNT;
        }

        // type => init next prev
        public List<int> GeneratePageNumbers(PageType type)
        {
            int initNum = 1;
            int endNum = 10;
            int numtmp = 0;

            //20 => 21~30
            switch (type)
            {
                case PageType.Init:
                    initNum = 1;
                    endNum = (initNum + 9 > maxPage) ? maxPage : initNum + 9;
                    break;
                case PageType.Next:
                    // max 30, current 30
                    initNum = (_currentPage / 10) * 10 + 1 <= maxPage
                        ? (_currentPage / 10) * 10 + 1
                        : ((_currentPage / 10) - 1) * 10 + 1;
                    endNum = (initNum + 9 > maxPage) ? maxPage : initNum + 9;
                    break;
                case PageType.Previous:
                    initNum = ((_currentPage - 2) / 10) * 10 + 1;
                    endNum = (initNum + 9 > maxPage) ? maxPage : initNum + 9;
                    break;
                case PageType.NextTurn:
                    numtmp = (_currentPage + 10 > maxPage) ? maxPage : _currentPage + 10;

                    initNum = (numtmp % 10 == 0)
                        ? ((numtmp / 10) - 1) * 10 + 1
                        : (numtmp / 10) * 10 + 1;

                    endNum = (initNum + 9 > maxPage) ? maxPage : initNum + 9;
                    break;
                case PageType.PrevTurn:
                    numtmp = (_currentPage - 10 <= 0) ? 1 : _currentPage - 10;
                    //currentPage = (currentPage - 10 < 0) ? 1 : currentPage - 10;
                    initNum = numtmp % 10 == 0
                        ? ((numtmp / 10) - 1) * 10 + 1
                        : (numtmp / 10) * 10 + 1;
                    endNum = (initNum + 9 > maxPage) ? maxPage : initNum + 9;
                    break;
            }
            List<int> pageList = GenerateList(initNum, endNum);
            return pageList;
        }

        public void JumpPage(int page)
        {
            _currentPage = page;
        }

        public int ChangePage(PageType type)
        {
            switch (type)
            {

                case PageType.Next:
                    _currentPage = _currentPage + 1 <= maxPage ? _currentPage + 1 : _currentPage;
                    return (_currentPage % 10 == 0) ? 10 : _currentPage % 10;
                case PageType.Previous:
                    _currentPage = _currentPage - 1 > 0 ? _currentPage - 1 : _currentPage;
                    return (_currentPage % 10 == 0) ? 10 : _currentPage % 10;
                case PageType.NextTurn:
                    _currentPage = _currentPage + 10 <= maxPage ? _currentPage + 10 : maxPage;
                    return (_currentPage % 10 == 0) ? 10 : _currentPage % 10;
                case PageType.PrevTurn:
                    _currentPage = _currentPage - 10 > 0 ? _currentPage - 10 : 1;
                    return (_currentPage % 10 == 0) ? 10 : _currentPage % 10;
                default: return _currentPage;
            }
        }

        public bool TurnCheck(PageType type, out int page)
        {
            page = _currentPage;
            switch (type)
            {
                case PageType.Next:
                    // false => 不能下一頁(page + 1 > maxPage)
                    return !(page + 1 > maxPage);
                case PageType.Previous:
                    return !(page - 1 < 1);
                case PageType.NextTurn:
                    // 是否可以+10
                    return !(page + 10 > maxPage);
                case PageType.PrevTurn:
                    // 是否可以-10
                    return !(page - 10 < 1);
                default: return false;
            }
        }

        private List<int> GenerateList(int initNum, int endNum)
        {
            List<int> pageList = new List<int>();
            for (int i = initNum; i <= endNum; i++)
            {
                pageList.Add(i);
            }

            return pageList;
        }
    }
}
