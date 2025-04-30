using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal interface IFlyable
    {
        /// <summary>
        /// Method to fly.
        /// </summary>
        void Fly();

        /// <summary>
        /// Method to land.
        /// </summary>
        void Land();
    }
}
