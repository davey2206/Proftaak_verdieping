using System;
using System.Collections.Generic;
using System.Drawing;

namespace Proftaak
{
    internal class KwartetClass
    {
        private Score score;
        private Random rng = new Random();

        private List<Card> cards = new List<Card>();
        private int[] empty = { 1, 2, 3, 4 };
        private int counter = 0;
        private int ans;

        public void getId(int u)
        {
            score = new Score(10, 6, u);
        }

        public void Get_List()
        {
            cards.Clear();
            counter = 0;
            ans = 0;
            for (int i = 0; i < empty.Length; i++)
            {
                empty[i] = i + 1;
            }
            int n = rng.Next(1, 5);

            switch (n)
            {
                case 1:
                    cards.Add(new Card(Properties.Resources.olifant, 1));
                    cards.Add(new Card(Properties.Resources.konijn, 2));
                    cards.Add(new Card(Properties.Resources.kat, 3));
                    cards.Add(new Card(Properties.Resources.hond, 4));
                    break;

                case 2:
                    cards.Add(new Card(Properties.Resources.broek, 1));
                    cards.Add(new Card(Properties.Resources.trui, 2));
                    cards.Add(new Card(Properties.Resources.hemd, 3));
                    cards.Add(new Card(Properties.Resources.tshirt, 4));
                    break;

                case 3:
                    cards.Add(new Card(Properties.Resources.pet, 1));
                    cards.Add(new Card(Properties.Resources.polo, 2));
                    cards.Add(new Card(Properties.Resources.polo2, 3));
                    cards.Add(new Card(Properties.Resources.tshirt, 4));
                    break;

                case 4:
                    cards.Add(new Card(Properties.Resources.spiegel, 1));
                    cards.Add(new Card(Properties.Resources.lip, 2));
                    cards.Add(new Card(Properties.Resources.maskara, 3));
                    cards.Add(new Card(Properties.Resources.poeder, 4));
                    break;
            }
        }

        public Image Set_Image()
        {
            int i = rng.Next(0, 4);
            while (empty[i] == 0)
            {
                i = rng.Next(0, 4);
            }
            empty[i] = 0;
            counter++;
            foreach (var card in cards)
            {
                if (card.Id == i + 1)
                {
                    if (card.Id == 1)
                    {
                        ans = counter;
                    }
                    return card.Picture;
                }
            }
            return null;
        }

        public bool Check(int n)
        {
            if (ans == n)
            {
                score.addScore(true);
                return true;
            }
            score.addScore(false);
            return false;
        }
    }
}