using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controllers
{
    /// <summary>
    /// Controller for the CommandViewModel to interface with the service layer.
    /// </summary>
    public partial class CommandController : ICommandController
    {
        #region Private Properties
        private ICommandService CommandService;
        #endregion

        #region Constructor
        public CommandController(ICommandService service)
        {
            CommandService = service;
            InitializeService();
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
        /// <summary>
        /// Sends a press event for the special command keys.
        /// </summary>
        /// <param name="command">The special command to send.</param>
        /// <param name="isPressDown">Whether or not the key will be pressed down, or up.</param>
        private void SpecialKeyCommand(byte command, bool isPressDown = true)
        {
            uint dwFlag = 0x00;

            if (isPressDown == true)
                dwFlag = 0x2;

            keybd_event(command, 0, dwFlag, 0);

            Thread.Sleep(20);
        }

        /// <summary>
        /// Sends a regular command to the Windows API.
        ///     The function sleeps the thread so that the keys are registered correctly
        ///     by the system.
        /// </summary>
        /// <param name="command">They command to send to the API.</param>
        /// <param name="presses">How many times the command should be pressed.</param>
        private void KeyCommand(byte command, uint presses)
        {
            for (uint i = 0; i < presses; ++i)
            {
                keybd_event(command, 0, 0, 0);  //  Press the key down.

                Thread.Sleep(20);

                keybd_event(command, 0, 0x2, 0);  //  Let the key up.

                Thread.Sleep(20);
            }
        }
        #endregion
    }
}
