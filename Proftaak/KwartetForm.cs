﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Proftaak
{
    public partial class KwartetForm : Form
    {
        KwartetClass game = new KwartetClass();
        Port serialPortEvent = new Port();
        public KwartetForm()
        {
            InitializeComponent();
            serialPortEvent.openPort();
            serialPortEvent.DataReceived += ProcessData;
            start();
        }

        public void check(int n)
        {
            if (game.Check(n))
            {
                serialPortEvent.WriteBack("G");
                this.BackgroundImage = Properties.Resources.Achtergrond_groen;
                Thread.Sleep(1500);
                this.BackgroundImage = Properties.Resources.Achtergrond;
                start();
            }
            else
            {
                serialPortEvent.WriteBack("F");
                this.BackgroundImage = Properties.Resources.Achtergrond_rood;
                Thread.Sleep(1500);
                this.BackgroundImage = Properties.Resources.Achtergrond;
                start();
            }
        }

        public void start()
        {
            game.Get_List();
            pictureBox1.Image = game.Set_Image();
            pictureBox2.Image = game.Set_Image();
            pictureBox3.Image = game.Set_Image();
            pictureBox4.Image = game.Set_Image();
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

            if (antwoord == "1")
            {
                check(1);
            }
            if (antwoord == "2")
            {
                check(2);
            }
            if (antwoord == "3")
            {
                check(3);
            }
            if (antwoord == "4")
            {
                check(4);
            }
        }
    }
}
