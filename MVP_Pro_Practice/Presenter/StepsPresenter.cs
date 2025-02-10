using MVP_Pro_Practice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Presenter
{
    internal class StepsPresenter : IStepsPresenter
    {
        IStepView stepView;

        public StepsPresenter(IStepView stepView)
        {
            this.stepView = stepView;
        }
        public void GetStepList()
        {
            List<StepModel> steps = new List<StepModel>();
            steps.Add(new StepModel { title = "Step 1", description = "Initialize the project structure." });
            steps.Add(new StepModel { title = "Step 2", description = "Configure the database connection." });
            steps.Add(new StepModel { title = "Step 3", description = "Implement the first API endpoint." });
            steps.Add(new StepModel { title = "Step 4", description = "Change the Last API endpoint." });

            this.stepView.StepListResponse(steps);
        }
    }
}
