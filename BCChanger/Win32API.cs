using System.Runtime.InteropServices;

namespace BCChanger
{
    public static class Win32API
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);

        [DllImport("user32.dll")]
        public static extern int GetSysColor(int nIndex);

        [DllImport("user32")]
        public static extern int SetSysColors(int nChanges, ref int lpSysColor, ref int lpColorValues);

        public const int SPI_SETDESKWALLPAPER = 0x14;
        public const int SPIF_UPDATEINIFILE = 0x01;
        public const int SPIF_SENDWININICHANGE = 0x02;
        public const int COLOR_BACKGROUND = 1;
    }
}
