using IOCServiceCollection.Attributes;
using MVP_Pro_Practice.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Models.Repository
{
    [Singleton]
    internal class StepRepository : IStepRepository
    {
        public List<StepModel> GetStepList()
        {
            return new List<StepModel>()
            {
                new StepModel { title = "Step 1", description = "Initialize the project structure." },
                new StepModel { title = "Step 2", description = "Configure the database connection." },
                new StepModel { title = "Step 3", description = "Implement the first API endpoint." },
                new StepModel { title = "Step 4", description = "Change the Last API endpoint." }
            };
        }
    }
}
