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

        //IStepsPresenter stepsPresenter;

        public Form1(IStepService service)
        {
            InitializeComponent();
            this.stepService = service;
            //this.stepsPresenter = new StepsPresenter(stepComponent1);
            InitSteps();
            stepComponent1.StepIndexChange += StepComponent1_StepIndexChange;
        }

        private void StepComponent1_StepIndexChange(object sender, int e)
        {
            Console.WriteLine(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stepComponent1.StepListResponse(stepService.GetStepList());
        }

        private void InitSteps()
        {
            //stepService.GetStepList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stepComponent1.AssignStepStatus(2);
            stepComponent1.AssignStepStatus(3);
            stepComponent1.AssignStepStatus(4);
        }
    }
}
