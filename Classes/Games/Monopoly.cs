using Newtonsoft.Json;

namespace WpfApp3.Classes.Games
{
    internal class Monopoly : Game
    {
        public Monopoly(Player player1, Player player2) : base(player1, player2)
        {
            _name = "Monopoly";
        }
        [JsonConstructor]
        public Monopoly(int id, int firstPlayerId, int secondPlayerId, bool isFinished, int? winnerId, int? loserId)
            : base(id, firstPlayerId, secondPlayerId, isFinished, winnerId, loserId) { }
    }
}
