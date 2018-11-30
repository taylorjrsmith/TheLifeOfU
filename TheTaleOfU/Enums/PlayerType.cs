using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTaleOfU.Enums
{
    [Flags]
    public enum PlayerType
    {
        TimeTraveller = 1,
        OfficeWorker = 2, 
        Criminal = 4,
        Wizard = 8,
        SuperHero = 16
    }
}
