using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class AutoForm : Form
    {
        private Vehicle vehicle;
        private Road game = new Road();
        private Port serialPortEvent = new Port();
        private int count = 0;
        private bool checking = false;

        public AutoForm(int id)
        {
            InitializeComponent();
            serialPortEvent.openPort();
            serialPortEvent.DataReceived += ProcessData;

            game.Make_vehicles();
            vehicle = game.getVehicle();
            vehicle_box.BackgroundImage = vehicle.Picture;
            game.getId(id);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!checking)
            {
                while (count > 3)
                {
                    white_box.BackgroundImage = game.setPosition();
                    green_box.BackgroundImage = game.setPosition();
                    blue_box.BackgroundImage = game.setPosition();
                    yellow_box.BackgroundImage = game.setPosition();
                    answerLb.Text = game.setAnswer();
                    checking = true;
                    count = 0;
                }
                vehicle_box.Location = new Point(vehicle_box.Location.X + vehicle.Speed, vehicle_box.Location.Y);
                if (vehicle_box.Location.X > 250 & vehicle_box.Location.X < 1100)
                {
                    vehicle_box.Visible = true;
                }
                else
                {
                    vehicle_box.Visible = false;
                }
                if (vehicle_box.Location.X > 1200)
                {
                    vehicle_box.Left = 145;
                    vehicle = game.getVehicle();
                    vehicle_box.BackgroundImage = vehicle.Picture;
                    count++;
                }
            }
        }

        public void CheckAnswer(int n)
        {
            if (game.check(n))
            {
                serialPortEvent.WriteBack("G");
                this.BackgroundImage = Properties.Resources.Autoweg_Achtergrond_groen1;
                Thread.Sleep(1000);
                this.BackgroundImage = Properties.Resources.autoweg_achtergrond;
                white_box.BackgroundImage = null;
                green_box.BackgroundImage = null;
                blue_box.BackgroundImage = null;
                yellow_box.BackgroundImage = null;
            }
            else
            {
                serialPortEvent.WriteBack("F");
                this.BackgroundImage = Properties.Resources.Autoweg_Achtergrond_rood1;
                Thread.Sleep(1000);
                this.BackgroundImage = Properties.Resources.autoweg_achtergrond;
                white_box.BackgroundImage = null;
                green_box.BackgroundImage = null;
                blue_box.BackgroundImage = null;
                yellow_box.BackgroundImage = null;
            }
            answerLb.Invoke((new MethodInvoker(delegate { answerLb.Text = ""; })));
            vehicle = game.getVehicle();
            vehicle_box.BackgroundImage = vehicle.Picture;
            checking = false;
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
            if (checking)
            {
                if (antwoord == "1")
                {
                    CheckAnswer(1);
                }
                else if (antwoord == "2")
                {
                    CheckAnswer(2);
                }
                else if (antwoord == "3")
                {
                    CheckAnswer(3);
                }
                else if (antwoord == "4")
                {
                    CheckAnswer(4);
                }
            }
        }
    }
}