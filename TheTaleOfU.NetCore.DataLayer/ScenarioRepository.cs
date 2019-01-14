using System;
using System.Collections.Generic;
using System.Text;
using TheTaleOfU.NetCore.EntityLayer;

namespace TheTaleOfU.NetCore.DataLayer
{

    public interface IScenarioRepository : IRepository<Scenario>
    {

        IUnitOfWork UnitOfWork { get; }
    }
    public class ScenarioRepository : Repository<Scenario>, IScenarioRepository
    {
        public IUnitOfWork UnitOfWork { get; }

        public ScenarioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }


    }
}
