using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int player2Points;
        private int player1Points;
        private readonly string player1Name;
        private readonly string player2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {

            if (PlayingInDeuce())
            {
                return IsTie()
                    ? "Deuce"
                    : AdvantageScoreInfo();
            }
            else 
            {
                return IsTie() ? GetCurrentTieScore() : GetCurrentScore();
            }
        }

        private bool IsTie() => player1Points == player2Points;

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Points++;
            else
                player2Points++;
        }
        private string CurrentGemWinner() => player1Points > player2Points ? player1Name : player2Name;
        private bool IsAdvantage() => Math.Abs(player1Points - player2Points) == 1;
        private bool PlayingInDeuce() => player1Points >= 4 || player2Points >= 4 || (player1Points + player2Points >= 6);
        private string AdvantageScoreInfo() => IsAdvantage() ? "Advantage " + CurrentGemWinner() : "Win for " + CurrentGemWinner();
        private string GetPoint(int score)
        {
            string[] points = { "Love", "Fifteen", "Thirty", "Forty" };
            return points[score];
        }
        private string GetCurrentTieScore() => GetPoint(player1Points) + "-All";
        private string GetCurrentScore() => GetPoint(player1Points) + "-" + GetPoint(player2Points);

    }
}

