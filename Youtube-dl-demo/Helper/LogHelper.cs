using System;
using System.Windows.Forms;

namespace Youtube_dl_demo.Helper
{
    public static class LogHelper
    {
        public static ListBox ListBox { get; set; }
        public static Form Form { get; set; }

        public static void AddLog(string log)
        {
            ThreadHelper.AddLog(Form, ListBox, $"[{DateTime.Now.ToString("dd/MM/yyyy HH:MM:ss")}] -- {log}");
        }
    }
}
