using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class LichtForm : Form
    {
        Port serialPortEvent = new Port();
        public LichtForm()
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
                serialPortEvent.closePort();
                this.Invoke(new MethodInvoker(this.Hide));
            }
            else if (antwoord == "G")
            {
                this.BackgroundImage = Properties.Resources.Achtergrond_groen;
                Thread.Sleep(1500);
                this.BackgroundImage = Properties.Resources.Achtergrond;
            }
            else if (antwoord == "F")
            {
                this.BackgroundImage = Properties.Resources.Achtergrond_rood;
                Thread.Sleep(1500);
                this.BackgroundImage = Properties.Resources.Achtergrond;
            }
        }
    }
}
