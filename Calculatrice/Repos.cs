using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calculatrice
{
    public class Repos
    {
        public void Organize(String pPath)
        {
            if (!System.IO.Directory.Exists(pPath))
            {
                throw new System.IO.DirectoryNotFoundException();
            }
            if (!Directory.Exists(pPath+"/TXT"))
            {
                Directory.CreateDirectory(pPath + "/TXT");
            }
            String[] tabFiles = Directory.GetFiles(pPath);
            foreach (string filename in tabFiles)
            {
                FileInfo oFileInfo = new FileInfo(filename);
               switch (oFileInfo.Extension.ToUpper())
                {
                    case ".TXT":
                        if (File.Exists(pPath+"/TXT/"+oFileInfo.Name))
                        {
                            File.Delete(pPath + "/TXT/" + oFileInfo.Name);
                        }
                        File.Move(filename,pPath+"/TXT/"+ oFileInfo.Name);
                        break;
                    case ".JPG":
                    case ".PNG":
                        if (File.Exists(pPath + "/IMG/" + oFileInfo.Name))
                        {
                            File.Delete(pPath + "/IMG/" + oFileInfo.Name);
                        }
                        File.Move(filename, pPath + "/IMG/" + oFileInfo.Name);
                        break;
                    case ".EXE":
                        if (File.Exists(pPath + "/BIN/" + oFileInfo.Name))
                        {
                            File.Delete(pPath + "/BIN/" + oFileInfo.Name);
                        }
                        File.Move(filename, pPath + "/BIN/" + oFileInfo.Name);
                        break;
                    case ".PDF":
                        if (File.Exists(pPath + "/DOCS/" + oFileInfo.Name))
                        {
                            File.Delete(pPath + "/DOCS/" + oFileInfo.Name);
                        }
                        File.Move(filename, pPath + "/DOCS/" + oFileInfo.Name);
                        break;
                }
            }
            String[] tabDir = Directory.GetDirectories(pPath);
            foreach (string Dirname in tabDir)
            {
                DirectoryInfo oDirInfo = new DirectoryInfo(Dirname);
                if (!oDirInfo.Name.Equals("TXT") && !oDirInfo.Name.Equals("IMG") && !oDirInfo.Name.Equals("EXE") && !oDirInfo.Name.Equals("DOCS"))
                {
                    Organize(oDirInfo.FullName);
                }
            }


        }
    }
}
