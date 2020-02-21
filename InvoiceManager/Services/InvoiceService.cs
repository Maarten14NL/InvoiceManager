using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Reflection;
using word = Microsoft.Office.Interop.Word;
using System.IO;

using System.IO.Compression;


namespace InvoiceManager.Services
{
    public class InvoiceService : Controller
    {
        // GET: InvoiceService
        public ActionResult Index()
        {
            return View();
        }

        private static object missing = Missing.Value;
         
        private void ReplacePlaceHolders(word.Application wordApp, object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object matchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object replace = 2;
            object wrap = 1;

            //word find and replace function.
            wordApp.Selection.Find.Execute(
                ref findText, 
                ref matchCase, 
                ref matchWholeWord, 
                ref matchWildCards, 
                ref matchSoundLike, 
                ref matchAllForms, 
                ref forward, 
                ref wrap, 
                ref format, 
                ref replaceText, 
                ref replace, 
                ref matchKashida, 
                ref matchDiactitics, 
                ref matchAlefHamza, 
                ref matchControl
              );
        }

        private void FillTables(word.Document document)
        {
            object test = "invoiceTable";

            word.Range wrdRng = document.Bookmarks.get_Item(ref test).Range;
            foreach (word.Table tables in wrdRng.Tables)
            {
                for (int i = 0; i < 5; i++)
                {
                    word.Table tab = tables;
                    word.Range range = tab.Range;

                    // Select the last row as source row.2
                    int selectedRow = tab.Rows.Count;

                    // Select and copy content of the source row.
                    range.Start = tab.Rows[selectedRow].Cells[1].Range.Start;
                    range.End = tab.Rows[selectedRow].Cells[tab.Rows[selectedRow].Cells.Count].Range.End;
                    range.Copy();

                    // Insert a new row after the last row.
                    tab.Rows.Add(ref missing);

                    // Moves the cursor to the first cell of target row.
                    range.Start = tab.Rows[tab.Rows.Count].Cells[1].Range.Start;
                    range.End = range.Start;

                    foreach (word.Cell cell in tab.Rows[selectedRow].Cells)
                    {
                        string field = cell.Range.Text;

                        field = field.Replace("<Invoice.Name>", "WTF");
                        field = field.Replace("<Invoice.Amount>", Convert.ToString(i));
                        field = field.Replace("<Invoice.Price>", Convert.ToString((i + 10) * 10));

                        cell.Range.Text = field;
                    }


                    // Paste values to target row.
                    if (i < 5 - 1)
                    {
                        range.Paste();
                    }
                }
            }
        }

        private void SaveDocument(word.Document document, object fileName)
        {
            try
            {
                string str = Convert.ToString(fileName);
                string fileType = str.Substring(str.LastIndexOf('.') + 1);

                object format = Missing.Value;
                switch (fileType)
                {
                    case "txt":
                        format = word.WdSaveFormat.wdFormatText;
                        break;
                    case "pdf":
                        format = word.WdSaveFormat.wdFormatPDF;
                        break;
                    case "docx":
                    default:
                        format = Missing.Value;
                        break;
                }


                document.SaveAs2(
                    ref fileName,
                    ref format, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing
                );
            }
            catch
            {
                Console.WriteLine("Can't save file is already in use");
            }
        }

        private static string GetDataFilePath() => HttpRuntime.AppDomainAppVirtualPath != null ?
    Path.Combine(HttpRuntime.AppDomainAppPath, "App_templates") :
    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


        public void Generate()
        {
            string invoiceName = "test";
            string templatePath = GetDataFilePath();
            //string path = Path.Combine(Environment.CurrentDirectory, @"App_templates\", file);

            object fileName = templatePath + "\\invoiceTemplate.docx";
            object invoiceFileName = templatePath + "\\"+ invoiceName+".docx";
            System.IO.File.Copy(fileName.ToString(), invoiceFileName.ToString(), true);

            word.Application wordApp = new word.Application();
            word.Document invoice = null;

            if (System.IO.File.Exists((string)invoiceFileName))
            {

                DateTime today = DateTime.Now;

                object readOnly = false;
                object isVisible = false;

                wordApp.Visible = false;

                invoice = wordApp.Documents.Open(
                    ref invoiceFileName,
                    ref missing,
                    ref readOnly,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing
                );

                invoice.Activate();

                //find and replace-
                this.ReplacePlaceHolders(wordApp, "<Today>", "18-02-2020");
                this.ReplacePlaceHolders(wordApp, "<Organisation.Name>", "test");
                this.ReplacePlaceHolders(wordApp, "<Organisation.Address>", "Radioweg 17");
                this.ReplacePlaceHolders(wordApp, "<Organisation.Postal>", "5844 AA, Stevensbeek");
                this.ReplacePlaceHolders(wordApp, "<Organisation.Phone>", "0620705928");
                this.ReplacePlaceHolders(wordApp, "<Organisation.Email>", "Radioweg 17");
                this.ReplacePlaceHolders(wordApp, "<Company.Name>", "Test bedrijf");
                this.ReplacePlaceHolders(wordApp, "<Organisation.Address>", "Radioweg 17");
                this.ReplacePlaceHolders(wordApp, "<Organisation.Address>", "Radioweg 17");
                this.ReplacePlaceHolders(wordApp, "<Organisation.Address>", "Radioweg 17");
                this.ReplacePlaceHolders(wordApp, "<Organisation.Address>", "Radioweg 17");

                //populate table
                this.FillTables(invoice);

                //save invoice
                object saveAs = templatePath + "\\" + invoiceName + ".pdf";
                this.SaveDocument(invoice, saveAs);

                //close Document
                invoice.Close(ref missing, ref missing, ref missing);
                this.deleteFile(templatePath + "\\" + invoiceName + ".docx");
            }
        }

        private void addToZip(string path)
        {
            string templatePath = GetDataFilePath();
        }

        private void deleteFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
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
    }
}