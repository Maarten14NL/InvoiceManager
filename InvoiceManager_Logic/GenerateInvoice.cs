using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using word = Microsoft.Office.Interop.Word;
using System.Web;
using InvoiceManager_Logic.Invoice;
using System.Web.UI.WebControls;

namespace InvoiceManager_Logic
{
    public class GenerateInvoice
    {
        public string GetDataFilePath { private get;  set; }

        private readonly FileService fileService = new FileService();
        private static object missing = Missing.Value;

        public GenerateInvoice(string projectPath)
        {
            GetDataFilePath = projectPath;
        }

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

        private void FillTables(word.Document document, List<List<PlaceHolder>> tableFields)
        {
            object test = "invoiceTable";

            word.Range wrdRng = document.Bookmarks.get_Item(ref test).Range;
            foreach (word.Table tables in wrdRng.Tables)
            {
                int rowCounter = 0;
                foreach (List<PlaceHolder> fields in tableFields)
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
                        foreach (PlaceHolder placeHolder in fields)
                        {
                            field = field.Replace(placeHolder.Placeholder, placeHolder.NewValue);
                        }

                        cell.Range.Text = field;
                    }


                    // Paste values to target row.
                    if (rowCounter < tableFields.Count - 1)
                    {
                        range.Paste();
                    }
                    rowCounter++;
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

        public void Generate(List<PlaceHolder> replaceWords, List<List<PlaceHolder>> tableFields)
        {
            string invoiceName = "test";
            string templatePath = GetDataFilePath;
            //string path = Path.Combine(Environment.CurrentDirectory, @"App_templates\", file);

            object fileName = templatePath + "\\invoiceTemplate.docx";
            object invoiceFileName = templatePath + "\\" + invoiceName + ".docx";
            fileService.CopyFile(fileName.ToString(), invoiceFileName.ToString());

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
                foreach (PlaceHolder replaceWord in replaceWords)
                {
                    ReplacePlaceHolders(wordApp, replaceWord.Placeholder, replaceWord.NewValue);
                }

                //populate table
                this.FillTables(invoice, tableFields);

                //save invoice
                object saveAs = templatePath + "\\" + invoiceName + ".pdf";
                this.SaveDocument(invoice, saveAs);

                //close Document
                invoice.Close(ref missing, ref missing, ref missing);
                fileService.Zip(templatePath, "invoice.zip", saveAs.ToString());
                fileService.DeleteFile(templatePath + "\\" + invoiceName + ".docx");
            }
        }
    }
}
