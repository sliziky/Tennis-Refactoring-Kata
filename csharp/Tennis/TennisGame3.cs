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
                if (player1Points == player2Points)
                    return "Deuce";
                string currentWinner = CurrentGemWinner();
                return IsAdvantage() ? "Advantage " + currentWinner : "Win for " + currentWinner;
            }
            else 
            {
                string[] points = { "Love", "Fifteen", "Thirty", "Forty" };
                return (player1Points == player2Points) ? points[player1Points] + "-All" : points[player1Points] + "-" + points[player2Points];
            }
        }

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

    }
}

