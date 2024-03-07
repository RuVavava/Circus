using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IWshRuntimeLibrary;

namespace Circus
{
    public class Label
    {
        public static void CreateLable(string ShortcutPath, string TargetPath)
        {
            WshShell wshShell = new WshShell(); //создаем объект wsh shell

            IWshShortcut Shortcut = (IWshShortcut)wshShell.CreateShortcut(ShortcutPath);

            Shortcut.TargetPath = TargetPath; //путь к целевому файлу

            Shortcut.Save();

        }

        //CreateLable(@"C:\test.lnk", @"C:\Windows\notepad.exe");
    }
}
