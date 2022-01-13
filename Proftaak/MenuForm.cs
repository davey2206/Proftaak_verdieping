using System.Text;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class MenuForm : Form
    {
        private Port serialPortEvent = new Port();
        private bool select = true;
        private int id;

        public MenuForm(int u)
        {
            InitializeComponent();
            serialPortEvent.openPort();
            serialPortEvent.DataReceived += ProcessData;
            id = u;
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
                    blue_btn.Invoke((new MethodInvoker(delegate { blue_btn.Visible = false; })));
                    green_btn.Invoke((new MethodInvoker(delegate { green_btn.Visible = false; })));
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
                    blue_btn.Invoke((new MethodInvoker(delegate { blue_btn.Visible = true; })));
                    green_btn.Invoke((new MethodInvoker(delegate { green_btn.Visible = true; })));
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
                    HomeGameForm homegame = new HomeGameForm(id);
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
                    DiscardForm discard = new DiscardForm(id);
                    discard.ShowDialog();
                    serialPortEvent.openPort();
                }
                else if (antwoord == "4")
                {
                    serialPortEvent.closePort();
                    AutoForm auto = new AutoForm(id);
                    auto.ShowDialog();
                    serialPortEvent.openPort();
                }
            }
            else
            {
                if (antwoord == "1")
                {
                    serialPortEvent.closePort();
                    OrderForm ordergame = new OrderForm(id);
                    ordergame.ShowDialog();
                    serialPortEvent.openPort();
                }

                if (antwoord == "4")
                {
                    serialPortEvent.closePort();
                    KwartetForm kwartet = new KwartetForm(id);
                    kwartet.ShowDialog();
                    serialPortEvent.openPort();
                }
            }
        }
    }
}