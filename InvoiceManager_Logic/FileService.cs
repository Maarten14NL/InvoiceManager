using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Logic
{
    class FileService
    {
        public void AddDirectory(string path)
        {
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void CopyFile(string pathOrgin, string pathNew)
        {
            if (File.Exists(pathOrgin))
            {
               File.Copy(pathOrgin, pathNew, true);
            }
        }

        public void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }

        public void Zip(string location, string zipFile, string documentFile)
        {
            string zipPath = location + "\\" + zipFile;
            string fileName = Path.GetFileName(documentFile);

            var zip = ZipFile.Open(zipPath, ZipArchiveMode.Update);
            zip.CreateEntryFromFile(documentFile, fileName);
            zip.Dispose();
        }
    }
}