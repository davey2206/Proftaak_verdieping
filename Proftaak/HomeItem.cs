using System.Drawing;

namespace Proftaak
{
    internal class HomeItem
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