using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proftaak
{
    class HomeItem
    {
        private int room;
        private Image picture;

        public HomeItem(int r, Image p)
        {
            room = r;
            picture = p;
        }

        public Image Picture
        {
            get { return picture; }
        }
        public int Room
        {
            get { return room; }
        }
    }
}
