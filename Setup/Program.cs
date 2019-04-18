using System;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Setup
{
    static class Program
    {
        private static Mutex Mutex;
        public static readonly string GUID =
            ((GuidAttribute)(Assembly.GetExecutingAssembly()).GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex = new Mutex(
                true,
                String.Format("Local\\{0}", GUID),
                out bool IsMutexOwner
            );

            const string Title = Common.Metadata.Name + " ASCOM Driver Setup";
            const string Text = "Only one instance of this program can be executed.";

            if (!IsMutexOwner)
            {
                MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.SetupForm());
            Mutex.ReleaseMutex();
        }
    }
}
