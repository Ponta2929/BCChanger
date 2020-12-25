using Microsoft.Win32;
using System.Drawing;

namespace BCChanger
{
    public static class ColorUtils
    {
        /// <summary>
        /// 現在の背景色を取得します。
        /// </summary>
        /// <returns></returns>
        public static Color GetColor()
        {
            // レジストリ取得
            var key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors");
            var val = (string)key.GetValue("Background");
            key.Close();

            // RGBデータ読み取り
            var cut = val.Split(' ');

            return Color.FromArgb(int.Parse(cut[0]), int.Parse(cut[1]), int.Parse(cut[2]));
        }

        /// <summary>
        /// 指定した色を背景色に適応します。
        /// </summary>
        /// <param name="r">R</param>
        /// <param name="g">G</param>
        /// <param name="b">B</param>
        public static void SetColor(int r, int g, int b)
        {
            // 背景色の適応
            var d = Win32API.COLOR_BACKGROUND;
            var v = ColorTranslator.ToWin32(Color.FromArgb(255, r, g, b));

            Win32API.SetSysColors(1, ref d, ref v);
            Win32API.SystemParametersInfo(0, 0, null, Win32API.SPIF_UPDATEINIFILE | Win32API.SPIF_SENDWININICHANGE);

            // レジストリ書き込み
            var key = Registry.CurrentUser.CreateSubKey(@"Control Panel\Colors");
            key.SetValue("Background", string.Format("{0} {1} {2}", r, g, b));
            key.Close();
        }
    }
}
