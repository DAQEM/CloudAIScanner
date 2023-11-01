using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class AIsystemService
    {
        private readonly IAISystemRepository _IaiSystemRepository;
        public AIsystemService(IAISystemRepository iaiSystemRepository)
        {
            _IaiSystemRepository = iaiSystemRepository;
        }

        public List<AISystem> GetAiSystems()
        {

            List<AISystemEntity> aiSystemEntities = _IaiSystemRepository.GetAiSystemsWithProvider();
            List<AISystem> aiSystems = new List<AISystem>();
            foreach (AISystemEntity aiSystem in aiSystemEntities)
            {
                AISystem newAISystem = new AISystem();
                newAISystem.toAISystem(aiSystem);
                aiSystems.Add(newAISystem);
            }
            return aiSystems;
        }

        public AISystem setAISystemById(Guid id)
        {
            AISystemEntity aisystemEntity = _IaiSystemRepository.GetAiSystemById(id);
            AISystem aisystem = new AISystem();
            aisystem.toAISystem(aisystemEntity);
            aisystem.setFiles(aisystemEntity);

            return aisystem;
        }
    }
}
