using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Pdf;


namespace Wpf2Word
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void btnFolderSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DirectoryInfo selectDir = new DirectoryInfo(txtFolder.Text);
            if (!selectDir.Exists)
            {
                textBox1.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}   目录{txtFolder.Text}不存在\n");
                return;
            }
            CycleTraver(selectDir);
        }

        private void CycleTraver(DirectoryInfo dir)
        {
            foreach (var fileInfo in dir.GetFiles("*.pdf"))
            {
                Wpf2Word(fileInfo);
                //BackgroundWorker thread = new BackgroundWorker();
                //thread.DoWork += ThreadOnDoWork;
                //thread.RunWorkerAsync(fileInfo);

            }
            textBox1.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}   目录{dir.Name}下文件转换完毕\n");
            foreach (var info in dir.GetDirectories())
            {
                CycleTraver(info);
            }
        }

        //private void ThreadOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        //{
        //    FileInfo file = doWorkEventArgs.Argument as FileInfo;
        //    if (file != null)
        //    {
        //        Wpf2Word(file);
        //    }
        //}

        private void Wpf2Word(FileInfo file)
        {
            try
            {
                Document pdfDoc = new Document(file.FullName);
                pdfDoc.Save(file.FullName.Replace("pdf", "doc"), SaveFormat.Doc);
                textBox1.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}   {file.Name}转换完成\n");
            }
            catch (Exception ex)
            {
                textBox1.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}   文件{file.Name}转换异常:" + ex.Message + "\n");

            }
        }

        private void Show(string msg)
        {
            textBox1.AppendText(msg);
        }
    }


}
