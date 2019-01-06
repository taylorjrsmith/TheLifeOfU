using System;
using System.Collections.Generic;
using System.Text;

namespace TheTaleOfU.NetCore.Shared
{
    public class ScenarioTransferObject
    {
        public string ScenarioName { get; set; }
        public string ScenarioDescription { get; set; }
        public List<ScenarioOptionTransferObject> Options { get; set; }
    }

    public class ScenarioOptionTransferObject
    {
        public string OptionText { get; set; }
        public string LinkedScenarioName { get; set; }
        public string OptionName { get; set; }
    }
}
