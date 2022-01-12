using System;
using System.Drawing;

namespace Proftaak
{
    internal class HomeGame
    {
        private Score score;
        private Random rng = new Random();

        private HomeItem homeItem;

        public void getId(int u)
        {
            score = new Score(10, 1, u);
        }

        public Image getImage()
        {
            int n = rng.Next(1, 14);
            switch (n)
            {
                case 1:
                    homeItem = new HomeItem(1, Properties.Resources.badeend);
                    break;

                case 2:
                    homeItem = new HomeItem(1, Properties.Resources.föhn1);
                    break;

                case 3:
                    homeItem = new HomeItem(1, Properties.Resources.tandenborstel1);
                    break;

                case 4:
                    homeItem = new HomeItem(1, Properties.Resources.borstel1);
                    break;

                case 5:
                    homeItem = new HomeItem(1, Properties.Resources.zeep1);
                    break;

                case 6:
                    homeItem = new HomeItem(1, Properties.Resources.wcpapier);
                    break;

                case 7:
                    homeItem = new HomeItem(4, Properties.Resources.bed1);
                    break;

                case 8:
                    homeItem = new HomeItem(4, Properties.Resources.teddybeer);
                    break;

                case 9:
                    homeItem = new HomeItem(4, Properties.Resources.kledingkast);
                    break;

                case 10:
                    homeItem = new HomeItem(4, Properties.Resources.kussen1);
                    break;

                case 11:
                    homeItem = new HomeItem(4, Properties.Resources.nachthemd);
                    break;

                case 12:
                    homeItem = new HomeItem(4, Properties.Resources.wekker1);
                    break;

                case 13:
                    homeItem = new HomeItem(3, Properties.Resources.ovenwant);
                    break;

                case 14:
                    homeItem = new HomeItem(3, Properties.Resources.deegroller1);
                    break;

                case 15:
                    homeItem = new HomeItem(3, Properties.Resources.appel1);
                    break;

                case 16:
                    homeItem = new HomeItem(3, Properties.Resources.mixer1);
                    break;

                case 17:
                    homeItem = new HomeItem(3, Properties.Resources.magnetron1);
                    break;

                case 18:
                    homeItem = new HomeItem(3, Properties.Resources.pan1);
                    break;

                case 19:
                    homeItem = new HomeItem(2, Properties.Resources.tv1);
                    break;

                case 20:
                    homeItem = new HomeItem(2, Properties.Resources.sofa);
                    break;

                case 21:
                    homeItem = new HomeItem(2, Properties.Resources.klok1);
                    break;

                case 22:
                    homeItem = new HomeItem(2, Properties.Resources.lamp1);
                    break;

                case 23:
                    homeItem = new HomeItem(2, Properties.Resources.openhaard1);
                    break;

                case 24:
                    homeItem = new HomeItem(2, Properties.Resources.tafel1);
                    break;
            }
            return homeItem.Picture;
        }

        public bool Check(int n)
        {
            if (homeItem.Room == n)
            {
                score.addScore(true);
                return true;
            }
            score.addScore(false);
            return false;
        }
    }
}