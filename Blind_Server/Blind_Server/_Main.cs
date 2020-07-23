using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace Blind_Server
{
    class _Main
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;

        static void Main(string[] args)
        {
            var handl = GetConsoleWindow();
            //ShowWindow(handl, SW_HIDE); //Console 창 숨기기
        }
    }
}
