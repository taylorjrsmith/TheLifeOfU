using System;
using System.Collections.Generic;
using System.Text;
using TheTaleOfU.NetCore.EntityLayer;
using TheTaleOfU.NetCore.Shared;

namespace TheTaleOfU.NetCore.ServiceLayer
{

    public interface IOptionProcessor
    {
        Option GenerateOption(ScenarioOptionTransferObject optionTransferObject);
    }
    public class OptionProcessor : IOptionProcessor
    {
        public Option GenerateOption(ScenarioOptionTransferObject optionTransferObject)
        {
            var option = new Option();
            option.Text = optionTransferObject.OptionText;
            option.Name = optionTransferObject.OptionName;

            return option;
        }

    }
}
