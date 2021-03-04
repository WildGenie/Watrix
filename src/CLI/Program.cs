﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using Core.Hotkeys;
using WinApi.User32;
using Core.POC;
namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            HotkeyManager manager = new HotkeyManager();
            manager.Register("a", "alt+control", () => { Console.WriteLine("alt+ctrl+a"); });
            manager.Register("escape", "shift", () => { manager.Stop(); });
            
            manager.Start();
            Console.WriteLine("Started service");
        }
    }
}