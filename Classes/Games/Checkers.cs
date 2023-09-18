using Newtonsoft.Json;

namespace WpfApp3.Classes.Games
{
    internal class Checkers : Game
    {
        public Checkers(Player player1, Player player2) : base(player1, player2)
        {
            _name = "Checkers";
        }
        [JsonConstructor]
        public Checkers(int id, int firstPlayerId, int secondPlayerId, bool isFinished, int? winnerId, int? loserId)
            : base(id, firstPlayerId, secondPlayerId, isFinished, winnerId, loserId) { }
    }
}
