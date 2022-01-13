using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class HomeGameForm : Form
    {
        private HomeGame game = new HomeGame();
        private Port serialPortEvent = new Port();

        public HomeGameForm(int id)
        {
            InitializeComponent();
            serialPortEvent.openPort();
            serialPortEvent.DataReceived += ProcessData;
            ItemPb.Image = game.getImage();
            game.getId(id);
        }

        public void check(int n)
        {
            if (game.Check(n))
            {
                serialPortEvent.WriteBack("G");
                this.BackgroundImage = Properties.Resources.Achtergrond_groen;
                Thread.Sleep(1000);
                this.BackgroundImage = Properties.Resources.Achtergrond;
                ItemPb.Image = game.getImage();
            }
            else
            {
                serialPortEvent.WriteBack("F");
                this.BackgroundImage = Properties.Resources.Achtergrond_rood;
                Thread.Sleep(1000);
                this.BackgroundImage = Properties.Resources.Achtergrond;
                ItemPb.Image = game.getImage();
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
            else if (antwoord == "1")
            {
                check(1);
            }
            else if (antwoord == "2")
            {
                check(2);
            }
            else if (antwoord == "3")
            {
                check(3);
            }
            else if (antwoord == "4")
            {
                check(4);
            }
        }

    }
}