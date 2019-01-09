using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TheTaleOfU.NetCore.EntityLayer.Enums;

namespace TheTaleOfU.NetCore.EntityLayer
{
    public class Scenario
    {
        public int Id { get; set; }
        public string ScenarioDescription { get; set; }
        public string ScenarioName { get; set; }
        public PlayerType AllowedPlayerTypes { get; set; }
        public List<Option> Options { get; set; }
        public bool IsEndOfScenarioRoute { get; set; }
        public string EndOfEventMethodName { get; set; }
        [NotMapped]
        public bool HasEvent => !string.IsNullOrEmpty(EndOfEventMethodName);
        [NotMapped]
        private Player CurrentPlayer { get; set; }
        /// <summary>
        /// The linked item is either an item that can be gained from this scenario or an item that can be used in this scenario
        /// </summary>
        //public virtual ScenarioEvent Event { get; set; }
    }
}
