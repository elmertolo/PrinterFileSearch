using Bond.IO.Unsafe;
using Ionic.Zip;
//using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
//using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterFile
{
    public partial class Main : Form
    {
     
        public Main()
        {
            InitializeComponent();
        }
        public int counter = 0;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string source = @"O:\Zips\Metro\" + txtYear.Text + @"\";
            string[] pdfFiles = GetFileNames(source, "*.zip");
            string target = "D:\\ExtractedTextFile\\";
            {
                Directory.CreateDirectory(target + txtYear.Text);

            }

            string destination = target + txtYear.Text + "\\";


            for (int i = 0; i < counter; i++)
            {
                {
                    Directory.CreateDirectory(destination + pdfFiles[i]);

                }

                string destination1 = destination + pdfFiles[i];

                using (ZipFile zip2 =ZipFile.Read(source+pdfFiles[i]))
                {
                    foreach (ZipEntry item in zip2)
                    {
                        if(item.FileName.EndsWith(".txt"))
                        {

                            item.Extract(destination1);
                           // MessageBox.Show("Files has been extracted!!");
                        }

                    }
                 
                }
                
            }
            MessageBox.Show("Files has been Extrated in this File Folder : " + target);
            //using (ZipFile zip = ZipFile.Read(source + pdfFiles[i]))
            //{

            //    //  string[] pdfFiles1 = GetFileNames(@"O:\Zips\Metro\2020\"+folderName, "*.txt");

            //    ZipEntry zip1 = zip[folderName + "\\" + textFileName + ".txt"];
            //    //foreach (ZipEntry zip1 in zip)
            //    //{

            //    zip1.Extract(target);
            //    //}

            //}
        }
        private  string[] GetFileNames(string path, string filter)
        {
            string[] files = Directory.GetFiles(path, filter);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
                counter++;
            }
            
            return files;
        }
        private string[] GetFolderName(string path, string filter)
        {
            string[] files = Directory.GetFiles(path, filter);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
                counter++;
            }

            return files;
        }
        private string[] GetTextFileName(string path, string filter)
        {
            string[] files = Directory.GetFiles(path, filter);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
                counter++;
            }

            return files;
        }
    }
}
