using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    internal class Score
    {
        private Database db = new Database();
        private int round = 0;
        private int maxround;
        private int score = 0;
        private int game;

        public Score(int m, int g, int u)
        {
            maxround = m;
            game = g;
            db.User = u;
        }

        public void addScore(bool g)
        {
            round++;
            if (round != maxround)
            {
                if (g)
                {
                    score++;
                }
            }
            else
            {
                db.setScore(game, score);
                round = 0;
            }
        }
    }
}