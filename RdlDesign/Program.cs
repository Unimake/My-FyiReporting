using System;
using System.Globalization;
using System.Windows.Forms;

namespace fyiReporting.RdlDesign
{
    public class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string version = "4563";// !!!! warning  !!!! string needs to be changed with when release version changes

            OpenPOS.GUID g = "";

            if(args.Length > 0)
            {
                if(args[0].StartsWith("GUID:"))
                {
                    g = args[0].Substring(5);
                }
            }

            // Determine if an instance is already running?
            bool firstInstance;
            string mName = string.Format("Local\\RdlDesigner{0}", version);
            //   can't use Assembly in this context
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, mName, out firstInstance);

            if(firstInstance)
            {// just start up the designer when we're first in line
                var thread = System.Threading.Thread.CurrentThread;

                try
                {
                    thread.CurrentCulture = new CultureInfo(DialogToolOptions.DesktopConfiguration.Language);
                }
                catch
                {
                    thread.CurrentCulture = new CultureInfo(thread.CurrentCulture.Name);
                }

                if(thread.CurrentCulture.Equals(CultureInfo.InvariantCulture))
                {
                    thread.CurrentCulture = new CultureInfo("en-US");
                }
                // for working in non-default cultures
                thread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
                thread.CurrentUICulture = thread.CurrentCulture;

                Application.EnableVisualStyles();
                Application.DoEvents();
                Application.Run(g.IsNullOrEmpty() ? new RdlDesigner(true) : new RdlDesigner(g));
                return;
            }
        }
    }
}
