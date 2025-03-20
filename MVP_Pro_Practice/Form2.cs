using MVP_Pro_Practice.Components.Pagy;
using MVP_Pro_Practice.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_Pro_Practice
{
    public partial class Form2 : Form
    {
        IPaginationService paginationService;
        APaginationView paginationView;
        public Form2(IPaginationService paginationService, APaginationView paginationView)
        {
            InitializeComponent();
            this.paginationService = paginationService;
            this.paginationView = paginationView;
            flowLayoutPanel1.Controls.Add(paginationView);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            paginationView.Total = paginationService.GetTotalPageNum();
        }
    }
}
