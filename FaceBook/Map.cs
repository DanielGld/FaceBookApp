using System.Windows.Forms;
using Microsoft.Win32;

namespace FaceBookUI
{
    public partial class Map : Form
    {
        private readonly string r_URL = "https://www.google.co.il/maps/search/?api=1&query=";
        private WebBrowser m_WebBrowser;

        public Map()
        {
            InitializeComponent();
            m_WebBrowser = new WebBrowser();
            string appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
            using (RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
            {
                Key.SetValue(appName, 99999, RegistryValueKind.DWord);
            }

            webBrowser1.ScriptErrorsSuppressed = true;
        }

        public void SetLocation(double i_Latitude, double i_Longitude)
        {
            webBrowser1.Navigate(r_URL + i_Latitude + "," + i_Longitude);
        }
    }
}
