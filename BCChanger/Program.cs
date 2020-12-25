using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCChanger
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static int Main()
        {
            var args = Environment.GetCommandLineArgs();
            var set = false;

            for (var i = 0; i < args.Length; i++)
            {
                if (args[i].Contains("/rgb"))
                {
                    ColorUtils.SetColor(int.Parse(args[i + 1]), int.Parse(args[i + 2]), int.Parse(args[i + 3]));
                    Console.WriteLine($"変更しました。 R:{int.Parse(args[i + 1])}, G : R:{int.Parse(args[i + 2])}, B:{int.Parse(args[i + 3])}");
                    set = true;
                }
                else if (args[i].Contains("/update"))
                {
                    var col = ColorUtils.GetColor();
                    ColorUtils.SetColor(col.R, col.G, col.B);
                    Console.WriteLine("更新されました。");
                    set = true;
                }
            }

            if (set)
                return 0;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            return 0;
        }
    }
}
