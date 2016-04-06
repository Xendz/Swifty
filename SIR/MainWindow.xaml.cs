using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NoteRefresh();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    

 
        public void button_Click(object sender, RoutedEventArgs e)
        {


            
                
            
            GetStartup();
            GetPList();
            GetUserAccount();
            GetNetstat();
            GetPcmd();
            GetSystemInfo();
            PVersion();
            
        }


        public void NoteRefresh()
        {
            string readit;
            if (File.Exists(@"c:\notes.txt"))
            {
               readit = File.ReadAllText(@"c:\notes.txt");
               textBox3.Text = readit;
                    
            }
        }

        public void PVersion()
        {
            string line;
            Process pash = new Process();

            pash.StartInfo.Arguments = String.Format("/c wmic /node:{0} qfe", textBox1.Text);
            pash.StartInfo.UseShellExecute = false;
            pash.StartInfo.FileName = "cmd";

            pash.StartInfo.RedirectStandardOutput = true;
            pash.StartInfo.CreateNoWindow = true;
            pash.Start();


            //p.WaitForExit();
            StreamReader srash = pash.StandardOutput;
            line = srash.ReadToEnd();
            txtBoxProduct.Text = line;
        }



        public void GetStartup()
        {
            String line;
            Process p = new Process();
            //  c:/PsExec.exe \\WKSP000670DB -u a-trj2mch -p GenDyn14!$ -s cmd.exe /c ipconfig
            p.StartInfo.Arguments = String.Format("/c wmic /node:{0} startup get name,location", textBox1.Text);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = "cmd";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            //p.WaitForExit();
            StreamReader sr = p.StandardOutput;
            line = sr.ReadToEnd();
            txtStartup.Text = line;

        }

        public void GetPList()
        {
            string line;
            Process pa = new Process();
            //      c:/PsExec.exe \\WKSP000670DB -u a-trj2mch -p GenDyn14!$ -s cmd.exe /c ipconfig
            pa.StartInfo.Arguments = String.Format("/c wmic /node:{0} process get name,processid,ExecutablePath", textBox1.Text);
            pa.StartInfo.UseShellExecute = false;
            pa.StartInfo.FileName = "cmd";
            pa.StartInfo.RedirectStandardOutput = true;
            pa.StartInfo.CreateNoWindow = true;
            pa.Start();
            //p.WaitForExit();
            StreamReader sra = pa.StandardOutput;
            line = sra.ReadToEnd();
            txtProcessList.Text = line;
        }

        public void GetUserAccount()
        {
            string line;
            Process pas = new Process();
            //      c:/PsExec.exe \\WKSP000670DB -u a-trj2mch -p GenDyn14!$ -s cmd.exe /c ipconfig
            pas.StartInfo.Arguments = String.Format("/c wmic /node:{0} useraccount", textBox1.Text);
            pas.StartInfo.UseShellExecute = false;
            pas.StartInfo.FileName = "cmd";
            pas.StartInfo.RedirectStandardOutput = true;
            pas.StartInfo.CreateNoWindow = true;
            pas.Start();
            //p.WaitForExit();
            StreamReader sras = pas.StandardOutput;
            line = sras.ReadToEnd();
            txtBoxAccounts.Text = line;

        }


        //PROCESS get Caption,Commandline,Processid
        public void GetPcmd()
        {
            string line;
            Process pav = new Process();
            //      c:/PsExec.exe \\WKSP000670DB -u a-trj2mch -p GenDyn14!$ -s cmd.exe /c ipconfig
            pav.StartInfo.Arguments = String.Format("/c wmic /node:{0} PROCESS get Caption,Commandline,Processid  / format:list", textBox1.Text);
            pav.StartInfo.UseShellExecute = false;
            pav.StartInfo.FileName = "cmd";
            pav.StartInfo.RedirectStandardOutput = true;
            pav.StartInfo.CreateNoWindow = true;
            pav.Start();
            //p.WaitForExit();
            StreamReader srav = pav.StandardOutput;
            line = srav.ReadToEnd();
            txtBoxcmd.Text = line;
        }


        public void GetNetstat()
        {
            

            Process paso = new Process();
            //      c:/PsExec.exe \\WKSP000670DB -u a-trj2mch -p GenDyn14!$ -s cmd.exe /c ipconfig
            paso.StartInfo.Arguments = String.Format("/c wmic /node:{0} process call create \"cmd /C >\\\\{0}\\C$\\netstat.txt 2>&1 netstat.exe -anob\"", textBox1.Text);
            paso.StartInfo.UseShellExecute = false;
            paso.StartInfo.FileName = "cmd";
            paso.StartInfo.RedirectStandardOutput = false;
            paso.StartInfo.CreateNoWindow = true;
            paso.Start();

         

        }

        public void GetSystemInfo()
        {


            string line;

            Process pasop = new Process();
            
            pasop.StartInfo.Arguments = String.Format("/c wmic /node:{0} cpu get Systemname,Name,Description,Manufacturer,AddressWidth,DeviceID / format:list", textBox1.Text);
            pasop.StartInfo.UseShellExecute = false;
            pasop.StartInfo.FileName = "cmd";
            pasop.StartInfo.RedirectStandardOutput = true;
            pasop.StartInfo.CreateNoWindow = true;
            pasop.Start();

            StreamReader sravp = pasop.StandardOutput;
            line = sravp.ReadToEnd();
            txtSysInfo.Text = line;
        }

        private void txtBoxProduct_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtBoxNetstat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtProcessList_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxcmd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSysInfo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSysInfo_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            string readout = File.ReadAllText(@"C:\\netstat.txt");
            txtBoxNetstat.Text = readout;
        }

        private void txtDecode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            byte[] data = Convert.FromBase64String(txtDecode.Text);
            string decodedString = Encoding.UTF8.GetString(data);
            txtOutputDecode.Text = decodedString;
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
     
            }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"c:\notes.txt", textBox3.Text);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string readit;
            if (File.Exists(@"c:\notes.txt"))
            {
                readit = File.ReadAllText(@"c:\notes.txt");
                textBox3.Text = readit;

            }
        }

        

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void earsButton_Click(object sender, RoutedEventArgs e)
        {
            this.WebBrowserEars.Navigate(String.Format("https://ears.inside.ups.com/EARS/search.aspx?s={0}", txtEars.Text));
        }
    }
    }

