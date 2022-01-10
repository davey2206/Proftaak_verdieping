using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proftaak
{
    public class Vehicle
    {
        private int speed = 20;
        private Image picture;
        private int id;

        public Vehicle(int n, Image P)
        {
            id = n;
            picture = P;
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public Image Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
