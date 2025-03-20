using IOCServiceCollection;
using MVP_Pro_Practice.Contracts;
using MVP_Pro_Practice.Models.Enum;
using MVP_Pro_Practice.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_Pro_Practice.Components.Pagy
{
    public partial class APaginationView : UserControl, IPaginationView
    {
        protected IPaginationPresenter _paginationPresenter;
        public APaginationView(PresenterFactory presenterFactory)
        {
            InitializeComponent();
            this._paginationPresenter = presenterFactory.Create<IPaginationPresenter, IPaginationView>(this);
            labelLeft.Click += LabelLastTurn_Click;
            labelRight.Click += LabelNextTurn_Click;
        }


        int total = 0; //總筆數

        //public event EventHandler<int> ChangePage;


        public int Total
        {
            get
            {
                return _paginationPresenter.TotalPageNum;
            }
            set
            {
                _paginationPresenter.TotalPageNum = value;
                GeneratePages(_paginationPresenter.GeneratePageNumbers(PageType.Init));
                TextLabel textLabel = (TextLabel)flowLayoutPanel1.Controls[1];
                textLabel.Active();
            }
        }

        private void Numlabel_Click(object sender, EventArgs e)
        {
            Reset();
            TextLabel textLabel = (TextLabel)sender;
            textLabel.Active();
            _paginationPresenter.JumpPage(int.Parse(textLabel.Text));
            //ChangePage.Invoke(this, _paginationPresenter.currentPage);
        }

        private void Labelback_Click(object sender, EventArgs e)
        {
            GeneratePages(_paginationPresenter.GeneratePageNumbers(PageType.Previous));
            TextLabel textLabel = (TextLabel)flowLayoutPanel1.Controls[_paginationPresenter.ChangePage(PageType.Previous)];
            textLabel.Active();
            //ChangePage.Invoke(this, _paginationPresenter.currentPage);

        }

        private void Labelfront_Click(object sender, EventArgs e)
        {
            GeneratePages(_paginationPresenter.GeneratePageNumbers(PageType.Next));
            TextLabel textLabel = (TextLabel)flowLayoutPanel1.Controls[_paginationPresenter.ChangePage(PageType.Next)];
            textLabel.Active();
            //ChangePage.Invoke(this, _paginationPresenter.currentPage);
        }

        public void GeneratePages(List<int> numlist)
        {
            flowLayoutPanel1.Controls.Clear();
            TextLabel labelback = new TextLabel("<");
            flowLayoutPanel1.Controls.Add(labelback);
            labelback.Click += Labelback_Click;

            foreach (int num in numlist)
            {
                TextLabel numlabel = new TextLabel($"{num}");
                flowLayoutPanel1.Controls.Add(numlabel);
                numlabel.Click += Numlabel_Click;
            }

            TextLabel labelfront = new TextLabel(">");
            flowLayoutPanel1.Controls.Add(labelfront);
            labelfront.Click += Labelfront_Click;
        }

        private void LabelNextTurn_Click(object sender, EventArgs e)
        {
            GeneratePages(_paginationPresenter.GeneratePageNumbers(PageType.NextTurn));
            TextLabel textLabel = (TextLabel)flowLayoutPanel1.Controls[_paginationPresenter.ChangePage(PageType.NextTurn)];
            textLabel.Active();

            //ChangePage.Invoke(this, _paginationPresenter.currentPage);
        }

        private void LabelLastTurn_Click(object sender, EventArgs e)
        {
            GeneratePages(_paginationPresenter.GeneratePageNumbers(PageType.PrevTurn));
            TextLabel textLabel = (TextLabel)flowLayoutPanel1.Controls[_paginationPresenter.ChangePage(PageType.PrevTurn)];
            textLabel.Active();

            //ChangePage.Invoke(this, _paginationPresenter.currentPage);
        }

        private void Reset()
        {
            foreach (TextLabel item in flowLayoutPanel1.Controls)
            {
                item.Normal();
            }
        }

        public void PaginationResponse(int totalPageNum)
        {
            _paginationPresenter.TotalPageNum = totalPageNum;
            GeneratePages(_paginationPresenter.GeneratePageNumbers(PageType.Init));
            TextLabel textLabel = (TextLabel)flowLayoutPanel1.Controls[1];
            textLabel.Active();
        }
    }
}
