using Models;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public partial class CommandController : ICommandController
    {
        /*
         * BEWARE, THERE IS SPAGHETTI CODE BELOW. I TAKE NO PRIDE IN THIS WORK.
         * Maybe I'll fix it someday, maybe not.
         */
        #region Private Properties
        private static string FilePath = @"C:\Users\nick_skinner\Desktop\WindowChanging\config.json";  //  Yes, I'm a monster.
        #endregion

        #region Service Initialization
        /// <summary>
        /// Initializes the service layer from the config.json file.
        /// </summary>
        private void InitializeService()
        {
            StreamReader sRead = new StreamReader(FilePath);

            string info = sRead.ReadToEnd();

            CommandSetLists cSetLists = JsonConvert.DeserializeObject<CommandSetLists>(info);

            //  Shield your eyes, unless you have the will to proceed.

            foreach (CommandSet set in cSetLists.PhoneCallSet)
            {
                CommandService.AddCommandSet(CommandSetType.CSTYPE_PHONE_CALL, set);
            }

            foreach (CommandSet set in cSetLists.WebchatSet)
            {
                CommandService.AddCommandSet(CommandSetType.CSTYPE_WEBCHAT, set);
            }

            foreach (CommandSet set in cSetLists.EmailSet)
            {
                CommandService.AddCommandSet(CommandSetType.CSTYPE_EMAIL, set);
            }

            foreach (CommandSet set in cSetLists.PersonalSet)
            {
                CommandService.AddCommandSet(CommandSetType.CSTYPE_PERSONAL, set);
            }
        }
        #endregion

        #region Nested Classes
        /// <summary>
        /// Used to get all of the lists easily with the JSON parser.
        /// </summary>
        private class CommandSetLists
        {
            public List<CommandSet> PhoneCallSet { get; set; }
            public List<CommandSet> WebchatSet { get; set; }
            public List<CommandSet> EmailSet { get; set; }
            public List<CommandSet> PersonalSet { get; set; }
        }
        #endregion
    }
}