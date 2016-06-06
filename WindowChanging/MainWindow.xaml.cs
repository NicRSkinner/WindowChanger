using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowChanging
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<CommandSet> CallSet = new List<CommandSet>();
        private List<CommandSet> ChatSet = new List<CommandSet>();
        private List<CommandSet> EmailSet = new List<CommandSet>();
        private List<CommandSet> PersonalSet = new List<CommandSet>();

        public MainWindow()
        {
            InitializeComponent();

            CallSet.Add(new CommandSet() { command = '1', isDoubled = false });
            CallSet.Add(new CommandSet() { command = '2', isDoubled = false });
            CallSet.Add(new CommandSet() { command = '4', isDoubled = true });
            CallSet.Add(new CommandSet() { command = '7', isDoubled = false });

            ChatSet.Add(new CommandSet() { command = '1', isDoubled = false });
            ChatSet.Add(new CommandSet() { command = '2', isDoubled = false });
            ChatSet.Add(new CommandSet() { command = '4', isDoubled = true });
            ChatSet.Add(new CommandSet() { command = '5', isDoubled = false });
            ChatSet.Add(new CommandSet() { command = '7', isDoubled = false });

            EmailSet.Add(new CommandSet() { command = '1', isDoubled = false });
            EmailSet.Add(new CommandSet() { command = '2', isDoubled = false });
            EmailSet.Add(new CommandSet() { command = '3', isDoubled = false });
            EmailSet.Add(new CommandSet() { command = '4', isDoubled = false });
            EmailSet.Add(new CommandSet() { command = '7', isDoubled = false });

            PersonalSet.Add(new CommandSet() { command = '1', isDoubled = true });
            PersonalSet.Add(new CommandSet() { command = '1', isDoubled = false });
            PersonalSet.Add(new CommandSet() { command = '2', isDoubled = false });
            PersonalSet.Add(new CommandSet() { command = '7', isDoubled = false });
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        private void BtnCall_Click(object sender, RoutedEventArgs e)
        {
            SendEvent(0x24, false);

            foreach (CommandSet cSet in CallSet)
            {
                SendEvent((byte)cSet.command, cSet.isDoubled);
            }
        }

        private void BtnChats_Click(object sender, RoutedEventArgs e)
        {
            SendEvent(0x24, false);

            foreach (CommandSet cSet in ChatSet)
            {
                SendEvent((byte)cSet.command, cSet.isDoubled);
            }
        }

        private void BtnEmail_Click(object sender, RoutedEventArgs e)
        {
            SendEvent(0x24, false);

            foreach (CommandSet cSet in EmailSet)
            {
                SendEvent((byte)cSet.command, cSet.isDoubled);
            }
        }

        private void BtnPersonal_Click(object sender, RoutedEventArgs e)
        {
            SendEvent(0x24, false);

            foreach(CommandSet cSet in PersonalSet)
            {
                SendEvent((byte)cSet.command, cSet.isDoubled);
            }
        }

        private void SendEvent(byte command, bool isDoubled = false)
        {
            keybd_event(0x5B, 0, 0, 0);  //  Send Windows Down

            Thread.Sleep(100);

            keybd_event(command, 0, 0, 0);  //  Send Command Down
            Thread.Sleep(100);
            keybd_event(command, 0, 0x2, 0);  //  Send Command Up

            if (isDoubled == true)
            {
                keybd_event(command, 0, 0, 0);  //  Send Command Down
                Thread.Sleep(100);
                keybd_event(command, 0, 0x2, 0);  //  Send Command Up
            }

            Thread.Sleep(100);

            keybd_event(0x5B, 0, 0x2, 0);  //  Send Windows Up

            Thread.Sleep(100);
        }
    }

    public class CommandSet
    {
        public char command;
        public bool isDoubled;
    }
}