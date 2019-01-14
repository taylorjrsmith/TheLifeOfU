using System;
using System.Linq;
using System.Threading.Tasks;
using TheTaleOfU.NetCore.DataLayer;
using TheTaleOfU.NetCore.EntityLayer;
using TheTaleOfU.NetCore.Shared;

namespace TheTaleOfU.NetCore.ServiceLayer
{

    public interface IScenarioProcessor
    {
        Task<string> WriteMessage(string message);
        void RunScenario(Player player, Scenario scenario);
        Scenario CreateScenario(ScenarioTransferObject scenarioTransferObject, IOptionProcessor optionProcessor);
    }

    public class ScenarioProcessor : IScenarioProcessor
    {

        public IScenarioRepository ScenarioRepository;
        public ScenarioProcessor(IScenarioRepository scenarioRepository)
        {
            ScenarioRepository = scenarioRepository;
        }

        public Task<string> WriteMessage(string message)
        {
            return Task.FromResult<string>("I am running");
        }

        public Scenario CreateScenario(ScenarioTransferObject scenarioTransferObject, IOptionProcessor optionProcessor)
        {
            var scenario = new Scenario();
            scenario.Description = scenarioTransferObject.ScenarioDescription;
            scenario.Name = scenarioTransferObject.ScenarioName;
            foreach (var o in scenarioTransferObject.Options)
            {
                scenario.Options.Add(optionProcessor.GenerateOption(o));
            }
            SaveScenario(scenario);

            return scenario;
        }

        public void SaveScenario(Scenario scenario)
        {
            if (scenario.Id == 0)
                ScenarioRepository.Add(scenario);
            else
            {
                ScenarioRepository.Update(scenario);
            }
            ScenarioRepository.UnitOfWork.Commit();
        }

        public void RunScenario(Player player, Scenario scenario)
        {
            //scenario.CurrentPlayer = player;
            //Console.WriteLine(scenario.ScenarioDescription);
            //if (scenario.IsEndOfScenarioRoute || scenario.HasEvent)
            //{
            //    scenario.Event = new TheTaleOfUContext().Events.FirstOrDefault(a => a.OriginScenarioId == Id);
            //    if (Event != null)
            //        CallEventFromString(EndOfEventMethodName);
            //}

            //if (Options == null)
            //    Options = new TheTaleOfUContext().Options.Where(a => a.OriginScenarioId == Id).ToList();

            //Console.ReadKey();
            //foreach (var o in Options)
            //{
            //    Console.WriteLine($"{o.OptionIdentifier} : {o.Text}");
            //}

            //string option = "";
            //var wasValidOption = false;
            //while (!wasValidOption)
            //{
            //    option = Console.ReadLine();
            //    wasValidOption = ProcessOption(option);
            //    if (!wasValidOption)
            //        Console.WriteLine("Please enter a valid option number");
            //}
            //var numericOption = Convert.ToInt32(option);

            //var nextOption = Options.FirstOrDefault(a => a.OptionIdentifier == numericOption);
            //var scenario = new TheTaleOfUContext().Scenarios.FirstOrDefault(a => a.Id == nextOption.NextScenarioId);
            //nextOption.NextScenario = scenario;
            //if (nextOption.NextScenario == null)
            //    return;
            //nextOption.NextScenario.RunScenario(player);

        }

        private bool ProcessOption(string selectedOption, Scenario scenario)
        {
            var strippedOption = selectedOption.Trim();

            if (!scenario.Options.Any(a => a.OptionIdentifier == Convert.ToInt32(strippedOption)))
            {
                return false;
            }
            return true;
        }

    }
}
