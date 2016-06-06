using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    /// <summary>
    /// Controller for the CommandViewModel to interface with the service layer.
    /// </summary>
    public class CommandController : ICommandController
    {
        #region Private Properties
        private ICommandService CommandService;
        #endregion

        #region Constructor
        public CommandController(ICommandService service)
        {
            CommandService = service;
        }
        #endregion

        #region ICommandController Implementation
        /// <summary>
        /// Adds a CommandSet to the SetList in the service layer.
        /// </summary>
        /// <param name="csType">The type of command to add.</param>
        /// <param name="data">The CommandSet data.</param>
        public void AddCommandSet(CommandSetType csType, CommandSet data)
        {
            CommandService.AddCommandSet(csType, data);
        }

        /// <summary>
        /// Removes a CommandSet from the SetList in the service layer.
        /// </summary>
        /// <param name="csType">The type of command to remove.</param>
        /// <param name="data">The CommandSet to remove.</param>
        public void RemoveCommandSet(CommandSetType csType, CommandSet data)
        {
            CommandService.RemoveCommandSet(csType, data);
        }

        /// <summary>
        /// Sends the PhoneCall CommandSet to the Windows API.
        /// </summary>
        public void HandlePhoneCallCommand()
        {

        }

        /// <summary>
        /// Sends the Webchat CommandSet to the Windows API.
        /// </summary>
        public void HandleWebchatCommand()
        {

        }

        /// <summary>
        /// Sends the Email CommandSet to the Windows API.
        /// </summary>
        public void HandleEmailCommand()
        {

        }

        /// <summary>
        /// Sends the Personal CommandSet to the Windows API.
        /// </summary>
        public void HandlePersonalCommand()
        {

        }
        #endregion

        #region Imported Methods
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        #endregion

        #region Private Properties

        #endregion
    }
}
