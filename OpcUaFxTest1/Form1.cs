using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.UaFx.Client;


namespace OpcUaFxTest1
{
    public partial class Form1 : Form
    {

        OpcClient client;
        uint second;

        public Form1()
        {
            InitializeComponent();

        }

        ~Form1()
        {
            client.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var val = client.ReadNode("ns=6;s=::AsGlobalPV:count");
            button1.Text = val.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new OpcClient("opc.tcp://127.0.0.1:4840");
            client.Connect();
            timer1.Start();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            second++;
            label1.Text = second.ToString();
        }
    }
}
