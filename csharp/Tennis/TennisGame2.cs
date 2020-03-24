namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";

        private string[] points = {"Love", "Fifteen", "Thirty","Forty"};
        public TennisGame2(string player1Name, string player2Name)
        {
            p1point = 0;
        }

        public string GetScore()
        {
            var score = "";
            if (IsTie() && p1point < 3)
            {
                score = points[p1point] + "-All";
            }
            if (IsTie() && p1point > 2)
                score = "Deuce";

            if (p1point > 0 && p2point == 0 && p1point < 4)
            {
                p1res = points[p1point];
                p2res = "Love";
                score = p1res + "-" + p2res;
            }
            if (p2point > 0 && p1point == 0 && p2point < 4)
            {
                p2res = points[p2point];
                p1res = "Love";
                score = p1res + "-" + p2res;
            }

            if (p1point > p2point && p1point < 4)
            {
                p2res = points[p2point];
                p1res = points[p1point];
                score = p1res + "-" + p2res;
            }
            if (p2point > p1point && p2point < 4)
            {
                p2res = points[p2point];
                p1res = points[p1point];
                score = p1res + "-" + p2res;
            }

            if (p1point > p2point && p2point >= 3)
            {
                score = "Advantage player1";
            }

            if (p2point > p1point && p1point >= 3)
            {
                score = "Advantage player2";
            }

            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = "Win for player1";
            }
            if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        private bool IsTie()
        {
            return p1point == p2point;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

