using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace RateIt.Utilities
{
    public class ContentIdTracker
    {
        public static long NextId()
        {
            var nextIdStr = ReadText();
            if (!string.IsNullOrEmpty(nextIdStr))
            {
                var id = long.Parse(nextIdStr);
                WriteText((id+1).ToString());
                return id;
            }
            return -1;
        }

        private static string ReadText()
        {
            var nextId = string.Empty;
            using (StreamReader readtext = new StreamReader(Path.Combine(GetHostPath() ,"ContentIdTracker.txt")))
            {
                nextId = readtext.ReadLine();
            }
            return nextId;
        }

        private static void WriteText(string text)
        {
            using (StreamWriter writetext = new StreamWriter(Path.Combine(GetHostPath(), "ContentIdTracker.txt")))
            {
                writetext.WriteLine(text);
            }
        }

        private static string GetHostPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = new DirectoryInfo(new DirectoryInfo(path).Parent.FullName).Parent.FullName;
            var virtualFolder = new Uri(path).LocalPath;
            return virtualFolder;
        }
    }
}
