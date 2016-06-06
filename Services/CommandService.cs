using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    /// <summary>
    /// Service used for storing and retrieving CommandSets.
    /// </summary>
    public class CommandService : ICommandService
    {
        #region Private Properties
        private List<CommandSet> PhoneCallSet;
        private List<CommandSet> WebchatSet;
        private List<CommandSet> EmailSet;
        private List<CommandSet> PersonalSet;
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor for initializing the sets.
        /// </summary>
        public CommandService()
        {
            PhoneCallSet = new List<CommandSet>();
            WebchatSet = new List<CommandSet>();
            EmailSet = new List<CommandSet>();
            PersonalSet = new List<CommandSet>();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Resolves a CommandSet list given its type.
        /// </summary>
        /// <param name="csType">The type of list CommandSet list to get.</param>
        /// <returns></returns>
        private IEnumerable<CommandSet> ResolveCommandSet(CommandSetType csType)
        {
            switch(csType)
            {
                case CommandSetType.CSTYPE_PHONE_CALL:
                    return PhoneCallSet;
                case CommandSetType.CSTYPE_WEBCHAT:
                    return WebchatSet;
                case CommandSetType.CSTYPE_EMAIL:
                    return EmailSet;
                case CommandSetType.CSTYPE_PERSONAL:
                    return PersonalSet;
                default:
                    throw new InvalidOperationException("CommandSet Type not supported!");
            }
        }
        #endregion

        #region ICommandService Implementation
        /// <summary>
        /// Gets a CommandSet list given its type.
        /// </summary>
        /// <param name="csType">The type of list CommandSet list to get.</param>
        /// <returns></returns>
        public IEnumerable<CommandSet> GetCommandSet(CommandSetType csType)
        {
            return ResolveCommandSet(csType);
        }

        /// <summary>
        /// Adds a CommandSet to the given SetType.
        /// </summary>
        /// <param name="csType">The SetType to add the command to.</param>
        /// <param name="data">The data to add to the SetType.</param>
        public void AddCommandSet(CommandSetType csType, CommandSet data)
        {
            List<CommandSet> SetList = ResolveCommandSet(csType) as List<CommandSet>;

            SetList.Add(data);
        }

        /// <summary>
        /// Removes a CommandSet from the given SetType.
        /// </summary>
        /// <param name="csType">The SetType to remove the CommandSet from.</param>
        /// <param name="data">The CommandSet to remove from the SetType.</param>
        public void RemoveCommandSet(CommandSetType csType, CommandSet data)
        {
            List<CommandSet> SetList = ResolveCommandSet(csType) as List<CommandSet>;

            SetList.Remove(data);
        }
        #endregion
    }
}