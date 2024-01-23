using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Cyclonian.GhBuddy
{
    public static class Tools
    {
        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        public static void WriteOut(RichTextBox rtb, StringBuilder sb, Color c, params string[] messages)
        {
            sb.Clear();
            foreach (string szMessage in messages)
                sb.AppendLine(szMessage);

            rtb.AppendText(sb.ToString(), c);
            rtb.Select(rtb.Text.Length - 1, 0);
            rtb.ScrollToCaret();
        }

        public static void WriteError(RichTextBox rtb, StringBuilder sb, Exception ex)
        {
            WriteOut(rtb, sb, Color.DarkRed, "ERROR");
            WriteOut(rtb, sb, Color.DarkRed, ex.Message);
            Exception inEx = ex.InnerException;
            while (inEx != null)
                WriteOut(rtb, sb, Color.DarkRed, inEx.Message);
        }

        public static void AppendText(this RichTextBox rtb, string text, Color color)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            rtb.SelectionColor = color;
            rtb.AppendText(text);
            rtb.SelectionColor = rtb.ForeColor;
        }

        public static int GetValue(XmlDocument doc, string szKey)
        {
            XmlNode node = doc.DocumentElement.SelectSingleNode("/result/" + szKey);
            if(node == null)
                return 0;
            if(node.InnerText == "None")
                return 0;
            int nResult = 0;
            int.TryParse(node.InnerText, out nResult);

            return nResult;
        }
    }
}


public static class ErrorProviderExtensions
{
    private static int count;

    public static void SetErrorWithCount(this ErrorProvider ep, Control c, string message)
    {
        if (message == "")
        {
            if (ep.GetError(c) != "")
                count--;
        }
        else if (ep.GetError(c) == "")
        {
            count++;
        }

        ep.SetError(c, message);
    }

    public static bool HasErrors(this ErrorProvider ep)
    {
        return count != 0;
    }

    public static int GetErrorCount(this ErrorProvider ep)
    {
        return count;
    }
}