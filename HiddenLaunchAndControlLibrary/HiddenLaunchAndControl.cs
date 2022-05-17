using SendKeys;
using System;
using System.Diagnostics;
using System.Text;


namespace HiddenLaunchAndControlLibrary
{


    public class HiddenLaunchAndControl
    {

        public void HiddenStart(string prog_path, string prog_name = "")
        {
            if (!isHaveProcess(prog_name))
            {
                ProcessStartInfo processStart = new ProcessStartInfo();
                processStart.FileName = prog_path;
                processStart.CreateNoWindow = false;
                processStart.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(processStart);
            }
        }

        bool isHaveProcess(string pName)
        {
            Process[] pList = Process.GetProcesses();
            foreach (Process myProcess in pList)
            {
                if (myProcess.ProcessName == pName)
                    return true;
            }
            return false;
        }

        public void SendKeys(string keys)
        {
            System.Windows.Forms.SendKeys.SendWait(keys); // отправить в окно ввод с клавиатуры
        }
        public bool SetForegroundWindowHidden(string window_name)
        {
            while ((NativeWin32.SetForegroundWindow(GetTaskWindows(window_name))) == 0)
            {
                NativeWin32.SetForegroundWindow(GetTaskWindows(window_name));
            }// фокус на приложение (ид процесса) повторить если процесс не найден
            return true;
        }
        int GetTaskWindows(string window_name)
        {
            int nDeshWndHandle = NativeWin32.GetDesktopWindow();
            int nChildHandle = NativeWin32.GetWindow(nDeshWndHandle, NativeWin32.GW_CHILD);
            while (nChildHandle != 0)
            {
                nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
                StringBuilder sbTitle = new StringBuilder(1024);
                NativeWin32.GetWindowText(nChildHandle, sbTitle, sbTitle.Capacity);
                String sWinTitle = sbTitle.ToString();
                if (sWinTitle == window_name)
                {
                    var test = nChildHandle;
                    return test;
                }
            }
            return 0;
        }
    }
}
