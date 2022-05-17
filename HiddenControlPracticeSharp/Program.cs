using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiddenLaunchAndControlLibrary;
namespace HiddenControlPracticeSharp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            HiddenLaunchAndControl processStart = new HiddenLaunchAndControl(); // создание экземпляра класса
            string prog_path = "C:\\Users\\User\\source\\repos\\practicesharp\\PracticeSharpApp\\bin\\Debug\\PracticeSharp.exe";
            string prog_name = "PracticeSharp"; // проверка запущенного процесса перед запуском
            processStart.HiddenStart(prog_path, prog_name); // запуск программы 
            if (processStart.SetForegroundWindowHidden("Practice# (2.1.0.0)"))// выбор окна
            {
                processStart.SendKeys(" "); // отправить ввод с клавиатуры
            }
        }
    }
}
