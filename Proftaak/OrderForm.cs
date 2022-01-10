using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class OrderForm : Form
    {

        OrderGame game = new OrderGame();
        Port serialPortEvent = new Port();
        bool btn1Check = true;
        bool btn2Check = true;
        bool btn3Check = true;
        bool btn4Check = true;
        public OrderForm()
        {
            InitializeComponent();
            serialPortEvent.openPort();
            serialPortEvent.DataReceived += ProcessData;
            start();
        }

        public void start()
        {
            game.CreateCards();
            pictureBox1.Image = game.setCard();
            pictureBox2.Image = game.setCard();
            pictureBox3.Image = game.setCard();
            pictureBox4.Image = game.setCard();
        }

        public void check(int n)
        {
            if (n == 2)
            {
                serialPortEvent.WriteBack("G");
                this.BackgroundImage = Properties.Resources.Achtergrond_groen;
                Thread.Sleep(1500);
                this.BackgroundImage = Properties.Resources.Achtergrond;
                start();
                btn1Check = true;
                btn2Check = true;
                btn3Check = true;
                btn4Check = true;
            }
            else if (n == 1)
            {
                serialPortEvent.WriteBack("F");
                this.BackgroundImage = Properties.Resources.Achtergrond_rood;
                Thread.Sleep(1500);
                this.BackgroundImage = Properties.Resources.Achtergrond;
                start();
                btn1Check = true;
                btn2Check = true;
                btn3Check = true;
                btn4Check = true;
            }
        }
        private void ProcessData(byte[] data)
        {
            string antwoord = Encoding.Default.GetString(data);
            antwoord = antwoord.Replace("\r\n", "");

            if (antwoord == "E")
            {
                serialPortEvent.closePort();
                this.Invoke(new MethodInvoker(this.Hide));
            }

            if (btn1Check)
            {
                if (antwoord == "1")
                {
                    btn1Check = false;
                    check(game.check(1));
                }
            }
            if (btn2Check)
            {
                if (antwoord == "2")
                {
                    btn2Check = false;
                    check(game.check(2));
                }
            }
            if (btn3Check)
            {
                if (antwoord == "3")
                {
                    btn3Check = false;
                    check(game.check(3));
                }
            }
            if (btn4Check)
            {
                if (antwoord == "4")
                {
                    btn4Check = false;
                    check(game.check(4));
                }
            }
        }
    }
}
