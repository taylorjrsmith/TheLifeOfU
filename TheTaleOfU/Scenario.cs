﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public bool hasEvent => !string.IsNullOrEmpty(EndOfEventMethodName);
        /// <summary>
        /// The linked item is either an item that can be gained from this scenario or an item that can be used in this scenario
        /// </summary>
        public Item LinkedItem { get; set; }

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
            var scenario = new TheTaleOfUContext().Scenarios.FirstOrDefault(a => a.Id == nextOption.NextScenarioId);
            nextOption.NextScenario = scenario;
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

        public void UseAnItem()
        {
            if (LinkedItem.Durability > 0)
            {
                LinkedItem.Durability--;
            }
        }

    }
}
