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
    public partial class Form1 : Form
    {
        List<StepModel> steps = new List<StepModel>();
        public int currentStep = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitStepModels();
            ChangeLabelColor(1);
        }

        public void ChangeLabelColor(int step)
        {
            if (step >= 1 && step <= flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>().Count())
            {
                for (int i = 0; i < steps.Count; i++)
                {
                    FlowLayoutPanel panel = flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>().ToList()[i];
                    panel.Controls.OfType<Label>().ToList().ForEach(x => x.ForeColor = Color.Black);
                }
                FlowLayoutPanel selectedPanel = flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>().ToList()[step - 1];
                selectedPanel.Controls.OfType<Label>().ToList().ForEach(x => x.ForeColor = Color.Blue);

                currentStep = step;
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(currentStep + 1);
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(currentStep - 1);
        }

        public void InitStepModels()
        {
            steps = new List<StepModel>
            {
                new StepModel { title = "Step 1", description = "Initialize the project structure." },
                new StepModel { title = "Step 2", description = "Configure the database connection." },
                new StepModel { title = "Step 3", description = "Implement the first API endpoint." }
            };

            foreach (StepModel step in steps)
            {

                Label step1 = new Label();
                step1.Width = 100;
                step1.Height = 30;
                step1.Text = step.title;
                step1.Font = new Font("微軟正黑體", 10f);
                step1.TextAlign = ContentAlignment.MiddleCenter;

                Label sbuStep1 = new Label();
                sbuStep1.Width = 100;
                sbuStep1.Height = 30;
                sbuStep1.Text = step.description;
                sbuStep1.Font = new Font("微軟正黑體", 8f);
                sbuStep1.TextAlign = ContentAlignment.MiddleCenter;

                FlowLayoutPanel step1FlowOutPanel = new FlowLayoutPanel();
                step1FlowOutPanel.Width = 110;
                step1FlowOutPanel.Height = 70;
                step1FlowOutPanel.BorderStyle = BorderStyle.FixedSingle;
                step1FlowOutPanel.Controls.Add(step1);
                step1FlowOutPanel.Controls.Add(sbuStep1);

                Panel line = new Panel();
                line.Width = 70;
                line.Height = 2;
                line.Margin = new Padding(0, 30, 0, 0);
                line.BackColor = Color.Blue;

                flowLayoutPanel1.Controls.Add(step1FlowOutPanel);
                flowLayoutPanel1.Controls.Add(line);

            }

            flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.Count - 1);
        }
    }
}
