using IOCServiceCollection.Attributes;
using MVP_Pro_Practice.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Services
{
    [Singleton]
    internal class StepService : IStepService
    {
        private readonly IStepRepository _stepRepository;

        public StepService(IStepRepository stepRepository)
        {
            _stepRepository = stepRepository;
        }
        public List<StepModel> GetStepList()
        {
            return _stepRepository.GetStepList();
        }
    }
}
