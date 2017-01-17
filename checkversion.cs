using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;

/*
* Just a class who do a web request for compare app version.
*/
namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string checkVersion()
        {
            string sURL;
            sURL = "http://localhost/version.php";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    Console.WriteLine("{0}:{1}", i, sLine);
                    return sLine;
                }

            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string actualVersion = "2";
            string version = checkVersion();
            if(version != null){
                if (!version.Equals(actualVersion))
                {
                    MessageBox.Show("Descarga la nueva version");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string actualVersion = "3";
            string version = checkVersion();
            if (version != null)
            {
                if (!version.Equals(actualVersion))
                {
                    MessageBox.Show("Descarga la nueva version");
                }

            }
        }
    }
}
