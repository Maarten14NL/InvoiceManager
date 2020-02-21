using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO.Compression;
using System.IO;

namespace InvoiceManager.Services
{
    public class FileService : Controller
    {

        public void AddDirectory(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void CopyFile(string pathOrgin, string pathNew)
        {
            if (System.IO.File.Exists(pathOrgin))
            {
                System.IO.File.Copy(pathOrgin, pathNew, true);
            }
        }

        public void DeleteFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                try
                {
                    System.IO.File.Delete(path);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }

        public void Zip(string location, string zipFile, string documentFile)
        {
            string zipPath = location + "\\" + zipFile;
            if (!System.IO.File.Exists(zipPath))
            {
                ZipFile.CreateFromDirectory(location, zipPath);
            }

            var zip = ZipFile.Open(zipPath, ZipArchiveMode.Update);
            zip.CreateEntryFromFile(documentFile, "test.pdf");
            zip.Dispose();
        }
    }
}