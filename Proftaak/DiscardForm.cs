using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class DiscardForm : Form
    {
        private Discard game = new Discard();
        private Port serialPortEvent = new Port();
        private bool Start = true;

        public DiscardForm()
        {
            InitializeComponent();
            serialPortEvent.openPort();
            serialPortEvent.DataReceived += ProcessData;
            game.MakeCards();
            blanco.Image = game.roll();
        }

        public void setCards()
        {
            blanco1.Image = game.getCard();
            blanco2.Image = game.getCard();
            blanco3.Image = game.getCard();
            blanco4.Image = game.getCard();

            int answer = game.setAnswer();
            switch (answer)
            {
                case 1:
                    blanco1.Image = blanco.Image;
                    break;

                case 2:
                    blanco2.Image = blanco.Image;
                    break;

                case 3:
                    blanco3.Image = blanco.Image;
                    break;

                case 4:
                    blanco4.Image = blanco.Image;
                    break;
            }

            blanco.Invoke((new MethodInvoker(delegate { blanco.Visible = false; })));
            blanco1.Invoke((new MethodInvoker(delegate { blanco1.Visible = true; })));
            blanco2.Invoke((new MethodInvoker(delegate { blanco2.Visible = true; })));
            blanco3.Invoke((new MethodInvoker(delegate { blanco3.Visible = true; })));
            blanco4.Invoke((new MethodInvoker(delegate { blanco4.Visible = true; })));
            white_btn.Invoke((new MethodInvoker(delegate { white_btn.Visible = true; })));
            yellow_btn.Invoke((new MethodInvoker(delegate { yellow_btn.Visible = true; })));
            blue_btn.Invoke((new MethodInvoker(delegate { blue_btn.Visible = true; })));
            green_btn.Invoke((new MethodInvoker(delegate { green_btn.Visible = true; })));
        }

        public void CheckAnswer(int n)
        {
            if (game.check(n))
            {
                blanco.Image = game.roll();
                serialPortEvent.WriteBack("G");

                this.BackgroundImage = Properties.Resources.Achtergrond_groen;
                Thread.Sleep(1000);
                this.BackgroundImage = Properties.Resources.Achtergrond;

                blanco.Invoke((new MethodInvoker(delegate { blanco.Visible = true; })));
                blanco1.Invoke((new MethodInvoker(delegate { blanco1.Visible = false; })));
                blanco2.Invoke((new MethodInvoker(delegate { blanco2.Visible = false; })));
                blanco3.Invoke((new MethodInvoker(delegate { blanco3.Visible = false; })));
                blanco4.Invoke((new MethodInvoker(delegate { blanco4.Visible = false; })));
                white_btn.Invoke((new MethodInvoker(delegate { white_btn.Visible = false; })));
                yellow_btn.Invoke((new MethodInvoker(delegate { yellow_btn.Visible = false; })));
                blue_btn.Invoke((new MethodInvoker(delegate { blue_btn.Visible = false; })));
                green_btn.Invoke((new MethodInvoker(delegate { green_btn.Visible = false; })));
            }
            else
            {
                Start = true;
                blanco.Image = game.roll();
                serialPortEvent.WriteBack("F");

                this.BackgroundImage = Properties.Resources.Achtergrond_rood;
                Thread.Sleep(1000);
                this.BackgroundImage = Properties.Resources.Achtergrond;

                blanco.Invoke((new MethodInvoker(delegate { blanco.Visible = true; })));
                blanco1.Invoke((new MethodInvoker(delegate { blanco1.Visible = false; })));
                blanco2.Invoke((new MethodInvoker(delegate { blanco2.Visible = false; })));
                blanco3.Invoke((new MethodInvoker(delegate { blanco3.Visible = false; })));
                blanco4.Invoke((new MethodInvoker(delegate { blanco4.Visible = false; })));
                white_btn.Invoke((new MethodInvoker(delegate { white_btn.Visible = false; })));
                yellow_btn.Invoke((new MethodInvoker(delegate { yellow_btn.Visible = false; })));
                blue_btn.Invoke((new MethodInvoker(delegate { blue_btn.Visible = false; })));
                green_btn.Invoke((new MethodInvoker(delegate { green_btn.Visible = false; })));
            }
        }

        private void ProcessData(byte[] data)
        {
            string antwoord = Encoding.Default.GetString(data);
            antwoord = antwoord.Replace("\r\n", "");

            if (Start)
            {
                if (antwoord == "E")
                {
                    serialPortEvent.closePort();
                    this.Invoke(new MethodInvoker(this.Hide));
                }
                else if (antwoord != null || antwoord != "")
                {
                    setCards();
                    Start = false;
                }
            }
            else
            {
                if (antwoord == "E")
                {
                    this.Invoke(new MethodInvoker(this.Hide));
                }
                for (int i = 0; i < 5; i++)
                {
                    if (antwoord == i.ToString())
                    {
                        CheckAnswer(i);
                        Start = true;
                    }
                }
            }
        }
    }
}