using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Classes
{
    public class AISystemCollection
    {
        private readonly IAISystem _IaISystem;


        private List<AISystem> _aiSystems;

        public IEnumerable<AISystem> AISystems
        {
            get { return _aiSystems; }
        }


        public AISystemCollection(IAISystem IaiSystem)
        {
            _IaISystem = IaiSystem;
            _aiSystems = new List<AISystem>();
        }

        public void SetAiSystemsWithProviders()
        {
            List<AISystemEntity>aiSystems = _IaISystem.GetAiSystemsWithProvider();

            foreach (AISystemEntity aiSystem in aiSystems)
            {
                AISystem newAISystem = new AISystem();
                newAISystem.toAISystem(aiSystem);
                _aiSystems.Add(newAISystem);
            }
        }
    }
}
