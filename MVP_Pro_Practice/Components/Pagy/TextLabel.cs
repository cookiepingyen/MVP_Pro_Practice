using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MVP_Pro_Practice.Components.Pagy
{
    internal class TextLabel : Label
    {
        public TextLabel(string text)
        {
            Width = 20;
            TextAlign = ContentAlignment.MiddleCenter;
            Text = text;
        }
        public void Active()
        {
            ForeColor = Color.Blue;
            this.Font = new Font(this.Font, FontStyle.Bold);
        }

        public void Normal()
        {
            ForeColor = Color.Black;
            this.Font = new Font(this.Font, FontStyle.Regular);
        }
    }
}
