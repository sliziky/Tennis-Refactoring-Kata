namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private readonly string[] points = {"Love", "Fifteen", "Thirty","Forty"};
        public TennisGame2(string player1Name, string player2Name)
        {
            p1point = 0;
        }

        public string GetScore()
        {
            var score = "";
            if (IsTie())
            {
                return IsDeuce() ? "Deuce" : points[p1point] + "-All";
            }
            if (p1point < 4 && p2point < 4)
            {
                return points[p1point] + "-" + points[p2point];
            }
            if (Player1HasAdvantage() || Player2HasAdvantage())
            {
                score = "Advantage player";
                score += Player1HasAdvantage() ? "1" : "2";
            }
            if (Player1Won() || Player2Won())
            {
                score = "Win for player";
                score += Player1Won() ? "1" : "2";
            }
            return score;
        }

        private bool IsDeuce()
        {
            return IsTie() && p1point > 2;
        }

        private bool Player1HasAdvantage()
        {
            return p1point > p2point && p2point >= 3;
        }

        private bool Player2HasAdvantage()
        {
            return p2point > p1point && p1point >= 3;
        }

        private bool Player2Won()
        {
            return p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2;
        }

        private bool Player1Won()
        {
            return p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2;
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

