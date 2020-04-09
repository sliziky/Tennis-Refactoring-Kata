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
            if (IsTie())
            {
                return IsDeuce() ? "Deuce" : points[p1point] + "-All";
            }
            if (p1point < 4 && p2point < 4)
            {
                return points[p1point] + "-" + points[p2point];
            }
            if (Player1Won() || Player2Won())
            {
                return "Win for player" + (Player1Won() ? "1" : "2");
            }
            if (Player1HasAdvantage() || Player2HasAdvantage())
            {
                return "Advantage player" + (Player1HasAdvantage() ? "1" : "2");
            }
            return "";
        }

        private bool IsDeuce() => IsTie() && p1point > 2;

        private bool Player1HasAdvantage() => p1point > p2point && p2point >= 3;

        private bool Player2HasAdvantage() => p2point > p1point && p1point >= 3;

        private bool Player2Won() => p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2;

        private bool Player1Won() => p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2;

        private bool IsTie() => p1point == p2point;

        public void WonPoint(string player)
        {
            if (player == "player1")
                p1point++;
            else
                p2point++;
        }

    }
}

