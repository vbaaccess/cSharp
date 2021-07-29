using System;
using System.IO;

namespace ClassLogs
{
    class ClassLogs
    {
        private bool m_SaveTheLogs = false;
        public bool SaveTheLogs
        {
            get { return m_SaveTheLogs; }
            set { m_SaveTheLogs = value; }
        }

        private string sDirectory;
        private string sFilePrefix;

        private string path;
        private string filepath;

        private string unaccomplishedLog = "";

        public ClassLogs()
        {
            initVariable();
        }

        public ClassLogs(bool newSaveTheLogs)
        {
            m_SaveTheLogs = newSaveTheLogs;
            initVariable();
        }

        private void initVariable()
        {
            sDirectory = "\\Logs";
            sFilePrefix = "Log_";

            path = AppDomain.CurrentDomain.BaseDirectory + sDirectory;
            filepath = path + "\\" + sFilePrefix + DateTime.Now.Date.Year + ".txt";
        }

        public void WriteToFile(string Message)
        {
            if (!m_SaveTheLogs) return;

            string sMessage = DateTime.Now + "." + DateTime.Now.Millisecond.ToString() + " : " + Message;

            if (unaccomplishedLog.Length != 0)
            {
                sMessage = unaccomplishedLog + " (!)\n" + sMessage;
                unaccomplishedLog = "";
            }

            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                if (!File.Exists(filepath))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLineAsync(sMessage);
                        sw.Close();
                    }
                }
                else
                {
                    // just write to 
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLineAsync(sMessage);
                        sw.Close();
                    }

                }
            }
            catch (IOException)
            {
                unaccomplishedLog = sMessage;
                //System.Windows.Forms.MessageBox.Show(e.Message + ":" + sMessage);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
