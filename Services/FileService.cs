using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;
using System.IO;

namespace Services
{
    public class FileService
    {
        private static string FilePath = @"C:\Users\nick_skinner\Desktop\WindowChanging\config.json";  //  Yes, I'm a monster.

        public static void InitializeCommandService(CommandService service)
        {
            StreamReader sRead = new StreamReader(FilePath);

            string info = sRead.ReadToEnd();

            CommandSetLists cSetLists = JsonConvert.DeserializeObject<CommandSetLists>(info);

            foreach (CommandSet set in cSetLists.PhoneCallSet)
            {
                service.AddCommandSet(CommandSetType.CSTYPE_PHONE_CALL, set);
            }
            
            foreach (CommandSet set in cSetLists.WebchatSet)
            {
                service.AddCommandSet(CommandSetType.CSTYPE_WEBCHAT, set);
            }
            
            foreach (CommandSet set in cSetLists.EmailSet)
            {
                service.AddCommandSet(CommandSetType.CSTYPE_EMAIL, set);
            }
            
            foreach (CommandSet set in cSetLists.PersonalSet)
            {
                service.AddCommandSet(CommandSetType.CSTYPE_PERSONAL, set);
            }
        }

        private class CommandSetLists
        {
            public List<CommandSet> PhoneCallSet { get; set; }
            public List<CommandSet> WebchatSet { get; set; }
            public List<CommandSet> EmailSet { get; set; }
            public List<CommandSet> PersonalSet { get; set; }
        }
    }
}
