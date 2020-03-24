namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string[] points = { "Love", "Fifteen", "Thirty", "Forty" };
        public TennisGame1(string player1Name, string player2Name)
        {

        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1++;
            else
                m_score2++;
        }

        public string GetScore()
        {
            string score = "";
            if (IsTie())
            {
                score = m_score1 switch
                {
                    0 => "Love-All",
                    1 => "Fifteen-All",
                    2 => "Thirty-All",
                    _ => "Deuce",
                };
            }
            else if (PlayingInDeuce())
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    int tempScore;
                    if (i == 1)
                    {
                        tempScore = m_score1;
                    }
                    else { score += "-"; tempScore = m_score2; }
                    score += points[tempScore];
                }
            }
            return score;
        }

        private bool PlayingInDeuce()
        {
            return m_score1 >= 4 || m_score2 >= 4;
        }

        private bool IsTie()
        {
            return m_score1 == m_score2;
        }
    }
}

