using System.Drawing;

namespace Proftaak
{
    class Card
    {
        private Image picture;
        private int id;

        public Card(Image p, int n)
        {
            picture = p;
            id = n;
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
