using System.Dynamic;

namespace HiddenLaunchAndControlLibrary
{

    public class PyWrapper : DynamicObject
    {

        // wrapped C# class
        private HiddenLaunchAndControl functions;

        // ctor
        public PyWrapper()
        {
            functions = new HiddenLaunchAndControl();
        }

        public void HiddenStart(string prog_path, string prog_name = "")
        {
            functions.HiddenStart(prog_path, prog_name = "");
        }

        public void SendKeys(string keys)
        {
            functions.SendKeys(keys);
        }

        public bool SetForegroundWindowHidden(string window_name)
        {
            if (functions.SetForegroundWindowHidden(window_name))  
                return true;
            return false;
        }

    }
}