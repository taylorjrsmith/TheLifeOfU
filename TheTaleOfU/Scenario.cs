using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheTaleOfU.Enums;

namespace TheTaleOfU
{
    public class Scenario
    {
        public int Id { get; set; }
        public string ScenarioDescription { get; set; }
        public PlayerType AllowedPlayerTypes { get; set; }
        public List<Option> Options { get; set; }
        public bool IsEndOfScenarioRoute { get; set; }
        public string EndOfEventMethodName { get; set; }
        public bool hasEvent { get; set; }

        public void RunScenario()
        {
            Console.WriteLine(ScenarioDescription);
            if (IsEndOfScenarioRoute || hasEvent)
            {
                CallEventFromString(EndOfEventMethodName);
                return;
            }

            Console.ReadKey();
            foreach (var o in Options)
            {
                Console.WriteLine($"{o.OptionIdentifier} : {o.Text}");
            }

            string option = "";
            var wasValidOption = false;
            while (!wasValidOption)
            {
                option = Console.ReadLine();
                wasValidOption = ProcessOption(option);
                if (!wasValidOption)
                    Console.WriteLine("Please enter a valid option number");
            }
            var numericOption = Convert.ToInt32(option);

            var nextOption = Options.FirstOrDefault(a => a.OptionIdentifier == numericOption);
            nextOption.NextScenario.RunScenario();

        }

        public bool ProcessOption(string selectedOption)
        {
            var strippedOption = selectedOption.Trim();

            if (!Options.Any(a => a.OptionIdentifier == Convert.ToInt32(strippedOption)))
            {
                return false;
            }
            return true;
        }


        public void CallEventFromString(string eventName)
        {
            MethodInfo mi = this.GetType().GetMethod(eventName);
            mi.Invoke(this, null);
        }

        public void UseShrinkRay()
        {

        }

    }
}
