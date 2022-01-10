using System;
using System.Collections.Generic;
using System.Drawing;

namespace Proftaak
{
    internal class Discard
    {
        private Score score = new Score(10, 4);
        private int[] number = { 1, 2, 3, 4, 5, 6, 7, 8 };
        private int answer;

        private Random rng = new Random();

        private List<Card> cards = new List<Card>();

        public void MakeCards()
        {
            cards.Add(new Card(Properties.Resources.cirkel, 1));
            cards.Add(new Card(Properties.Resources.driehoek, 2));
            cards.Add(new Card(Properties.Resources.hartje, 3));
            cards.Add(new Card(Properties.Resources.ruit, 4));
            cards.Add(new Card(Properties.Resources.ster, 5));
            cards.Add(new Card(Properties.Resources.klaver, 6));
            cards.Add(new Card(Properties.Resources.schop, 7));
            cards.Add(new Card(Properties.Resources.vierkant, 8));
        }

        public int setAnswer()
        {
            int n = rng.Next(1, 5);

            answer = n;

            return n;
        }

        public Image getCard()
        {
            Random rng = new Random();

            int n = rng.Next(1, 8);
            while (number[n] == 0)
            {
                n = rng.Next(1, 8);
            }

            number[n] = 0;

            foreach (var card in cards)
            {
                if (card.Id == n)
                {
                    return card.Picture;
                }
            }

            return null;
        }

        public Image roll()
        {
            for (int i = 0; i < 8; i++)
            {
                number[i] = i + 1;
            }
            int n = rng.Next(1, 8);

            number[n] = 0;

            foreach (var card in cards)
            {
                if (card.Id == n)
                {
                    return card.Picture;
                }
            }

            return null;
        }

        public bool check(int a)
        {
            if (answer == a)
            {
                score.addScore(true);
                return true;
            }
            score.addScore(false);
            return false;
        }
    }
}