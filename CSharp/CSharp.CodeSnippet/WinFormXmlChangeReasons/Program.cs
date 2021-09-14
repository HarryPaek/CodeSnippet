using log4net;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace WinFormXmlChangeReasons
{
    static class Program
    {
        private static ILog _logger = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // SetCultureInfo(new CultureInfo("en-US"));
            SetCultureInfo();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary>
        /// 지정한 Locale로 프로그램 CultureInfo 설정
        /// </summary>
        private static void SetCultureInfo()
        {
            SetCultureInfo(Thread.CurrentThread.CurrentUICulture);
        }

        /// <summary>
        /// 지정한 Locale로 프로그램 CultureInfo 설정
        /// </summary>
        private static void SetCultureInfo(CultureInfo userLocale)
        {
            if (_logger != null)
                _logger.DebugFormat("SetCultureInfo(), userLocale=[{0}]", userLocale);

            if (userLocale == null)
                throw new ArgumentNullException(nameof(userLocale));

            try
            {
                if (_logger != null)
                    _logger.DebugFormat("SetCultureInfo(), userLocale=[{0}]", userLocale);

                //Culture for any thread
                Thread.CurrentThread.CurrentCulture = userLocale;

                //Culture for UI in any thread
                Thread.CurrentThread.CurrentUICulture = userLocale;
            }
            catch
            {
            }
        }
    }
}
