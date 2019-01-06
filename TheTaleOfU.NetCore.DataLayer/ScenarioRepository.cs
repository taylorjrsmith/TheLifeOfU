using System;
using System.Collections.Generic;
using System.Text;
using TheTaleOfU.NetCore.EntityLayer;

namespace TheTaleOfU.NetCore.DataLayer
{

    public interface IScenarioRepository
    {

    }
    public class ScenarioRepository : Repository<Scenario>, IScenarioRepository
    {

        public ScenarioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
