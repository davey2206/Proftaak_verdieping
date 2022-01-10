using System;
using System.Collections.Generic;
using System.Drawing;

namespace Proftaak
{
    class OrderGame
    {
        List<Card> cards = new List<Card>();
        Random rng = new Random();
        bool complete = false;
        int counter = 0;
        int[] empty = { 1, 2, 3, 4 };
        int[] order = { 0, 0, 0, 0 };
        int[] answer = { 0, 0, 0, 0 };

        public void CreateCards()
        {
            cards.Clear();
            for (int i = 0; i < empty.Length; i++)
            {
                empty[i] = i + 1;
                order[i] = 0;
                answer[i] = 0;
            }
            counter = 0;

            int n = rng.Next(1, 4);

            switch (n)
            {
                case 1:
                    cards.Add(new Card(Properties.Resources.brood1, 1));
                    cards.Add(new Card(Properties.Resources.brood2, 2));
                    cards.Add(new Card(Properties.Resources.brood3, 3));
                    cards.Add(new Card(Properties.Resources.brood4, 4));
                    break;
                case 2:
                    cards.Add(new Card(Properties.Resources.tea1, 1));
                    cards.Add(new Card(Properties.Resources.tea2, 2));
                    cards.Add(new Card(Properties.Resources.tea3, 3));
                    cards.Add(new Card(Properties.Resources.tea4, 4));
                    break;
                case 3:
                    cards.Add(new Card(Properties.Resources.poets, 1));
                    cards.Add(new Card(Properties.Resources.poets2, 2));
                    cards.Add(new Card(Properties.Resources.poets3, 3));
                    cards.Add(new Card(Properties.Resources.poets4, 4));
                    break;
            }
        }

        public Image setCard()
        {
            int n = rng.Next(0, 4);
            while (empty[n] == 0)
            {
                n = rng.Next(0, 4);
            }
            empty[n] = 0;

            foreach (var card in cards)
            {
                if (card.Id == n + 1)
                {
                    counter++;
                    order[n] = counter;
                    return card.Picture;
                }
            }
            return null;
        }

        public int check(int n)
        {
            if (counter > 3)
            {
                counter = 0;
            }
            answer[counter] = n;
            counter++;

            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] != 0)
                {
                    complete = true;
                }
                else
                {
                    complete = false;
                }
            }

            if (complete)
            {
                bool check = false;
                if (answer[0] == order[0] && answer[1] == order[1] && answer[2] == order[2] && answer[3] == order[3])
                {
                    check = true;
                }
                else
                {
                    check = false;
                }

                if (check)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
