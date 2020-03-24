using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private readonly string[] points = { "Love", "Fifteen", "Thirty", "Forty" };
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
            string score;
            if (IsTie())
            {
                if (IsDeuce()) { return "Deuce"; }
                return $"{points[m_score1]}-All";
            }
            else if (PlayingInDeuce())
            {
                var minusResult = m_score1 - m_score2;
                return EvaluateResult(minusResult);
            }
            else
            {
                return $"{points[m_score1]}-{points[m_score2]}";
            }
            return score;
        }

        private string EvaluateResult(int minusResult)
        {
            if (minusResult == 1) return "Advantage player1";
            else if (minusResult == -1) return "Advantage player2";
            else if (minusResult >= 2) return "Win for player1";
            return "Win for player2";
        }

        private bool IsDeuce()
        {
            return m_score1 >= 3 && m_score1 == m_score2;
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

