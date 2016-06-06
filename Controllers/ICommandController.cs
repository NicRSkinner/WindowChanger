using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    /// <summary>
    /// The interface for the CommandController to use.
    /// </summary>
    public interface ICommandController
    {
        void AddCommandSet(CommandSetType csType, CommandSet data);

        void RemoveCommandSet(CommandSetType csType, CommandSet data);

        void HandlePhoneCallCommand();

        void HandleWebchatCommand();

        void HandleEmailCommand();

        void HandlePersonalCommand();
    }
}
