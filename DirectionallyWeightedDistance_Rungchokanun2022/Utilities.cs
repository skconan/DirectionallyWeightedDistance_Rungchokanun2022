using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectionallyWeightedDistance_Rungchokanun2022
{
    public class Utilities
    {
        public static List<string> GetFilePath(string dirName, string[] filters)
        {
            List<string> fileList = new List<string>();
            List<string> dirList = Directory.GetDirectories(dirName).ToList();

            foreach (string fileName in Directory.GetFiles(dirName))
            {
                foreach (string f in filters)
                {
                    if (fileName.Contains(f))
                    {
                        fileList.Add(fileName);
                    }
                }
            }
            foreach (string d in dirList)
            {
                fileList.AddRange(GetFilePath(d, filters));
            }
            return fileList;
        }

        public static string SelectDir()
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                return fbd.SelectedPath;
            }
            else
            {
                return null;
            }
        }
        public static string SelectFile()
        {
            var ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
            {
                return ofd.FileName;
            }
            else
            {
                return null;
            }
        }
    }
}
