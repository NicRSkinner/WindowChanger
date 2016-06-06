using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Contains information about a command that will be sent to the Windows API.
    /// </summary>
    public class CommandSet
    {
        #region Public Properties
        public CommandTypes CommandType;

        //  The keycode for the command.
        public byte Command;

        //  Number of times to press the command before letting up on the modifier.
        public uint Presses;
        #endregion
    }
}
