using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SummaryInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            Process cmd = new Process();
            string dirUser = Environment.GetEnvironmentVariable("USERPROFILE");
            string programFileRute = Environment.GetEnvironmentVariable("ProgramFiles");
            string programFileRute86 = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            string raiz = System.Environment.SystemDirectory.Remove(3);
            string startup = dirUser + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup";
            string ruteIntall = programFileRute86 + "\\EmailService";
            if (String.IsNullOrEmpty(programFileRute86))
            {
                ruteIntall = programFileRute + "\\EmailService";
            }
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            try
            {
                if (!System.IO.Directory.Exists(raiz + "\\EmailService"))
                {
                    System.IO.Directory.CreateDirectory(raiz + "\\EmailService");
                }
                /* Copia de archivos a nueva carpeta en disco
                 * string kbFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "SendEmailSmsApp.exe");
                string destkb = System.IO.Path.Combine(raiz + "\\EmailService", "SendEmailSmsApp.exe");
                System.IO.File.Copy(kbFile, destkb, true);
                */
                //---
                using (StreamWriter writer = new StreamWriter(raiz + "\\EmailService\\SendEmailSmsApp.url"))
                {
                    string app = ruteIntall + "\\SendEmailSmsApp.exe";
                    writer.WriteLine("[InternetShortcut]");
                    writer.WriteLine("URL=file:///" + app);
                    writer.WriteLine("IconIndex=0");
                    string icon = app.Replace('\\', '/');
                    writer.WriteLine("IconFile=" + icon);
                    writer.Flush();
                }
                //---
                /* Copia el archivo y lo pasa a la carpeta Inicio
                string sourceFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "SendEmailSmsApp.exe");
                string destFile = System.IO.Path.Combine(startup, "SendEmailSmsApp.exe");
                System.IO.File.Copy(sourceFile, destFile, true);
                */
                using (StreamWriter writer = new StreamWriter(startup + "\\SendEmailSmsApp.url"))
                {
                    string app = ruteIntall + "\\SendEmailSmsApp.exe";
                    writer.WriteLine("[InternetShortcut]");
                    writer.WriteLine("URL=file:///" + app);
                    writer.WriteLine("IconIndex=0");
                    string icon = app.Replace('\\', '/');
                    writer.WriteLine("IconFile=" + icon);
                    writer.Flush();
                }
                cmd.Start();
                cmd.StandardInput.WriteLine("start /b " + raiz + "\\EmailService\\SendEmailSmsApp.exe");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();


            }
            catch (Exception e)
            {
                if (!System.IO.Directory.Exists(raiz + "\\EmailService"))
                {
                    System.IO.Directory.CreateDirectory(raiz + "\\EmailService");
                }
                /* Copia de archivos a nueva carpeta en disco
                 * string kbFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "SendEmailSmsApp.exe");
                string destkb = System.IO.Path.Combine(raiz + "\\EmailService", "SendEmailSmsApp.exe");
                System.IO.File.Copy(kbFile, destkb, true);
                */
                //---
                using (StreamWriter writer = new StreamWriter(raiz + "\\EmailService\\SendEmailSmsApp.url"))
                {
                    string app = ruteIntall + "\\SendEmailSmsApp.exe";
                    writer.WriteLine("[InternetShortcut]");
                    writer.WriteLine("URL=file:///" + app);
                    writer.WriteLine("IconIndex=0");
                    string icon = app.Replace('\\', '/');
                    writer.WriteLine("IconFile=" + icon);
                    writer.Flush();
                }
                //---
                /* Copia el archivo y lo pasa a la carpeta Inicio
                string sourceFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "SendEmailSmsApp.exe");
                string destFile = System.IO.Path.Combine(startup, "SendEmailSmsApp.exe");
                System.IO.File.Copy(sourceFile, destFile, true);
                */
                using (StreamWriter writer = new StreamWriter(startup + "\\SendEmailSmsApp.url"))
                {
                    string app = ruteIntall + "\\SendEmailSmsApp.exe";
                    writer.WriteLine("[InternetShortcut]");
                    writer.WriteLine("URL=file:///" + app);
                    writer.WriteLine("IconIndex=0");
                    string icon = app.Replace('\\', '/');
                    writer.WriteLine("IconFile=" + icon);
                    writer.Flush();
                }
                
                cmd.Start();
                cmd.StandardInput.WriteLine("start /b " + raiz + "\\EmailService\\SendEmailSmsApp.exe");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
            }
        }
    }
}
