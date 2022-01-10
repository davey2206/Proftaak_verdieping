using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class MenuForm : Form
    {
        Port serialPortEvent = new Port();
        bool select = true;
        
        public MenuForm()
        {
            InitializeComponent();
            serialPortEvent.openPort();
            serialPortEvent.DataReceived += ProcessData;
        }

        private void ProcessData(byte[] data)
        {
            string antwoord = Encoding.Default.GetString(data);
            antwoord = antwoord.Replace("\r\n", "");

            if (antwoord == "E")
            {
                if (select)
                {
                    pictureBox1.Invoke((new MethodInvoker(delegate { pictureBox1.Visible = false; })));
                    pictureBox2.Invoke((new MethodInvoker(delegate { pictureBox2.Visible = false; })));
                    pictureBox3.Invoke((new MethodInvoker(delegate { pictureBox3.Visible = false; })));
                    pictureBox4.Invoke((new MethodInvoker(delegate { pictureBox4.Visible = false; })));
                    pictureBox5.Invoke((new MethodInvoker(delegate { pictureBox5.Visible = true; })));
                    pictureBox6.Invoke((new MethodInvoker(delegate { pictureBox6.Visible = true; })));
                    select = false;
                }
                else
                {
                    pictureBox1.Invoke((new MethodInvoker(delegate { pictureBox1.Visible = true; })));
                    pictureBox2.Invoke((new MethodInvoker(delegate { pictureBox2.Visible = true; })));
                    pictureBox3.Invoke((new MethodInvoker(delegate { pictureBox3.Visible = true; })));
                    pictureBox4.Invoke((new MethodInvoker(delegate { pictureBox4.Visible = true; })));
                    pictureBox5.Invoke((new MethodInvoker(delegate { pictureBox5.Visible = false; })));
                    pictureBox6.Invoke((new MethodInvoker(delegate { pictureBox6.Visible = false; })));
                    select = true;
                }
            }

            if (select)
            {
                if (antwoord == "1")
                {
                    serialPortEvent.closePort();
                    HomeGameForm homegame = new HomeGameForm();
                    homegame.ShowDialog();
                    serialPortEvent.openPort();
                }
                else if (antwoord == "2")
                {
                    serialPortEvent.closePort();
                    LichtForm licht = new LichtForm();
                    licht.ShowDialog();
                    serialPortEvent.openPort();
                }
                else if (antwoord == "3")
                {
                    serialPortEvent.closePort();
                    DiscardForm discard = new DiscardForm();
                    discard.ShowDialog();
                    serialPortEvent.openPort();
                }
                else if (antwoord == "4")
                {
                    serialPortEvent.closePort();
                    AutoForm auto = new AutoForm();
                    auto.ShowDialog();
                    serialPortEvent.openPort();
                }
            }
            else
            {
                if (antwoord == "1")
                {
                    serialPortEvent.closePort();
                    OrderForm ordergame = new OrderForm();
                    ordergame.ShowDialog();
                    serialPortEvent.openPort();
                }

                if (antwoord == "4")
                {
                    serialPortEvent.closePort();
                    KwartetForm kwartet = new KwartetForm();
                    kwartet.ShowDialog();
                    serialPortEvent.openPort();
                }
            }
        }
    }
}
