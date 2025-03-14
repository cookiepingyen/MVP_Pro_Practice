using MVP_Pro_Practice.Components;
using MVP_Pro_Practice.Contracts;
using MVP_Pro_Practice.Presenter;
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
    public partial class Form1 : Form
    {
        List<StepModel> steps = new List<StepModel>();
        public int currentStep = 1;
        IStepService stepService;
        AStepsView stepView;

        public Form1(IStepService service, AStepsView stepView)
        {
            InitializeComponent();
            this.stepService = service;
            InitSteps();
            this.stepView = stepView;
            flowLayoutPanel1.Controls.Add(stepView);
            this.stepView.StepIndexChange += StepComponent1_StepIndexChange;
        }

        private void StepComponent1_StepIndexChange(object sender, int e)
        {
            Console.WriteLine(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stepView.StepListResponse(stepService.GetStepList());
        }

        private void InitSteps()
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            stepView.AssignStepStatus(2);
            stepView.AssignStepStatus(3);
            stepView.AssignStepStatus(4);
        }
    }
}
