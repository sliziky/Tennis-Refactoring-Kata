namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int p2;
        private int p1;
        private readonly string p1N;
        private readonly string p2N;

        public TennisGame3(string player1Name, string player2Name)
        {
            p1N = player1Name;
            p2N = player2Name;
        }

        public string GetScore()
        {
            string s;
            if (p1 < 4 && p2 < 4 && (p1 + p2 < 6))
            {
                string[] p = { "Love", "Fifteen", "Thirty", "Forty" };
                s = p[p1];
                return (p1 == p2) ? s + "-All" : s + "-" + p[p2];
            }
            else
            {
                if (p1 == p2)
                    return "Deuce";
                s = p1 > p2 ? p1N : p2N;
                return ((p1 - p2) * (p1 - p2) == 1) ? "Advantage " + s : "Win for " + s;
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                p1++;
            else
                p2++;
        }

    }
}

