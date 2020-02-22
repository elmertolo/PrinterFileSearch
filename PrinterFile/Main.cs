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
            string target = Application.StartupPath + "\\ExtractedTextFile\\";
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
                           // File.Delete(destination1 + "\\Regular\\BlockC.txt");
                           
                            // MessageBox.Show("Files has been extracted!!");\
                            
                        }
                       

                    }
                 
                }
                //if (File.Exists(source + pdfFiles[i] + "TimeCheckFiles.txt"))
                //{
                //    File.Delete("BlockC.txt");
                //    File.Delete("BlockP.txt");
                //    File.Delete("PackingA.txt");
                //    File.Delete("PackingB.txt");
                //    File.Delete("SortRT.txt");
                //    File.Delete("TimeCheckFiles.text");
                //    File.Delete("TimeGenerate.text");
                //}

            }
            //for (int a = 0; a < counter; a++)
            //{


            //    if (File.Exists(source + pdfFiles[a] + "\\Regular\\BlockC.txt"))
            //    {

            //    }
            //    else
            //    {
            //        File.Delete(source + pdfFiles[a] + "TimeCheckFiles.text");
            //        File.Delete(source + pdfFiles[a] + "TimeGenerate.text");
            //        File.Delete(source + pdfFiles[a] + "\\Regular\\BlockC.txt");
            //        File.Delete(source + pdfFiles[a] + "\\Regular\\BlockP.txt");
            //        File.Delete(source + pdfFiles[a] + "\\Regular\\PackingA.txt");
            //        File.Delete(source + pdfFiles[a] + "\\Regular\\PackingB.txt");
            //        File.Delete(source + pdfFiles[a] + "\\Regular\\SortRT.txt");
                   
            //        //MessageBox.Show("PANGET KA MALAYA KANA!!!");
            //    }
            //}
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
        private string[] GetFolderName(string path)
        {
            string[] files = Directory.GetDirectories(path);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
                counter++;
            }

            return files;
        }
        private string[] GetFolderName2(string path)
        {
            string[] files = Directory.GetDirectories(path);
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
        public void DeleteZipfile(string path)
        {

            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles("*.txt")
                     .Where(p => p.Extension == "*.txt").ToArray();
            foreach (FileInfo file in files)
            {
                file.Attributes = FileAttributes.Normal;
                File.Delete(file.FullName);
            }
        }
        private void btnSTexFile_Click(object sender, EventArgs e)
        {
            //StreamReader file;
            string source = Application.StartupPath +"\\ExtractedTextFile\\"+ txtYear.Text + @"\";
            string[] pdfFiles = GetFolderName(source);
            
           
            string path = "D:\\Sample.txt";
            foreach (var item in pdfFiles)
            {
                string[] iFolderName = GetFolderName2(source + item);
                foreach (var item2 in iFolderName)
                {
                    string[] filepaths = Directory.GetFiles(source + item + "\\" + item2 + "\\", "*.txt", SearchOption.AllDirectories);
                   
                    foreach (var items in filepaths)
                    {
                        string text = File.ReadAllText(items);
                        //  MessageBox.Show(items);
                        FileInfo file2 = new FileInfo(items);
                        
                     //   string fileName = items;
                       // MessageBox.Show(file2.Name) ;
                        if (text.Contains(txtSearch.Text))
                            File.Copy(items, Application.StartupPath + "\\MoveFile\\" + file2.Name,true);
                        //else
                        //    MessageBox.Show(txtSearch.Text);
                    }
                
                }
                

            }


            MessageBox.Show("HEllo!");
            //foreach (var item in pdfFiles)
            //{
            //    using (file = new StreamReader(File.OpenRead(source + item + "\\Regular\\BlockC.txt")))
            //    {

            //        MessageBox.Show("Hello!");
            //    }
            //}
         
            ////DeleteZipfile();
            //for (int i = 0; i < counter; i++)
            //{
            //    string path = source + pdfFiles[i]+"\\Regular\\PackingA.txt";
            //    if (File.Exists(source + pdfFiles[i] + "\\Regular\\BlockP.txt"))
            //    {
            //        //File.Delete(path);
            //         DeleteZipfile(@"D:\ExtractedTextFile\2016\AFT__ACT622_CWS314_PVL239_PVM107_REG550_JRD.zip\Regular\");
            //        MessageBox.Show(path);
            //   }
            //    else
            //        MessageBox.Show("Wala syang pake!!");
            //}
            
            //MessageBox.Show("Done!!!");
        }
    }
}
