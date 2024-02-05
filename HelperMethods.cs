
using System;
using System.IO;
using System.Windows.Forms;

namespace Geming.SimpleRec
{
    internal static class HelperMethods
    {
        private static string _appPath = String.Empty;

        private static string AddSepChar(string path)
        {
            if (path.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.OrdinalIgnoreCase))
                path += Path.DirectorySeparatorChar.ToString();

            return path;
        }

        public static string GetAppPath()
        {
            if (String.IsNullOrEmpty(_appPath))
                _appPath = AddSepChar(Application.StartupPath);

            return _appPath;
        }

        public static string GetRecordingsPath()
        {
            string path = AddSepChar(Path.Combine(GetAppPath(), "Recordings"));
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);

            return path;
        }

        public static string[] GetRecordings()
        {
            return Directory.GetFiles(GetRecordingsPath(), "*.wav");
        }

        public static string GetNewRecording(string timeStr)
        {
            return Path.Combine(GetRecordingsPath(), DateTime.Now.ToString("MMddyyyy-HHmmss-",System.Globalization.CultureInfo.InvariantCulture) + timeStr + ".wav");
        }

        public static void ErrMsgBox(IWin32Window owner, string msg) { MsgBox(owner, msg, MessageBoxIcon.Error); }
        public static DialogResult AskMsgBox(IWin32Window owner, string msg) { return MsgBox(owner, msg, MessageBoxIcon.Question); }
        public static DialogResult MsgBox(IWin32Window owner, string msg, MessageBoxIcon ico)
        {
            if (ico == MessageBoxIcon.Error)
                return MessageBox.Show(owner, msg, Application.ProductName, MessageBoxButtons.OK, ico);
            else if (ico == MessageBoxIcon.Question)
                return MessageBox.Show(owner, msg, Application.ProductName, MessageBoxButtons.YesNo, ico);
            else
                return MessageBox.Show(owner, msg, Application.ProductName, MessageBoxButtons.OK, ico);
        }
        

        public static string GetTimeStr(int length)
        {
            string str;
            str = ((int)length / (60 * 60)).ToString("00") + ":";
            length = length % (60 * 60);
            str += ((int)length / (1000 * 60)).ToString("00") + ":";
            length = length % (60);
            str += (length).ToString("00");
            
            return str;
        }
    }
}