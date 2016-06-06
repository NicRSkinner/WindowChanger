using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface ICommandService
    {
        IEnumerable<CommandSet> GetCommandSet(CommandSetType csType);

        void AddCommandSet(CommandSetType csType, CommandSet data);

        void RemoveCommandSet(CommandSetType csType, CommandSet data);
    }
}
