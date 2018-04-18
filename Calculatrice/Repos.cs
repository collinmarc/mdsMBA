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
                FileInfo oFileInfo = new FileInfo(pPath + "/" + filename);
               switch (oFileInfo.Extension)
                {
                    case ".txt":
                        if (File.Exists(pPath+"/TXT/"+oFileInfo.Name))
                        {
                            File.Delete(pPath + "/TXT/" + oFileInfo.Name);
                        }
                        File.Move(filename,pPath+"/TXT/"+ oFileInfo.Name);
                        break;
                }
            }

        }
    }
}
