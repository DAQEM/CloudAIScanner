using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IAISystemRepository
    {
        public List<AISystemEntity> GetAiSystemsWithProvider();

        public AISystemEntity GetAiSystemById(Guid id);
    }
}
