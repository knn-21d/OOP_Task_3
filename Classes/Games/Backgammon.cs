using Newtonsoft.Json;
using System;

namespace WpfApp3.Classes.Games
{
    internal class Backgammon : Game
    {
        public override bool IsDrawn => false;

        public Backgammon(Player player1, Player player2) : base(player1, player2)
        {
            _name = "Backgammon";
        }
        [JsonConstructor]
        public Backgammon(int id, int firstPlayerId, int secondPlayerId, bool isFinished, int? winnerId, int? loserId)
            : base(id, firstPlayerId, secondPlayerId, isFinished, winnerId, loserId) { }

        public override void FinishGame()
        {
            Random rnd = new();
            int roll = rnd.Next(1, 100);
            if (roll < 51)
            {
                Winner = Player1;
                Loser = Player2;
            }
            else
            {
                Winner = Player2;
                Loser = Player1;
            }
            IsFinished = true;
        }
    }
}
