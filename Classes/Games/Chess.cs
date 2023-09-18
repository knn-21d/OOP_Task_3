using Newtonsoft.Json;

namespace WpfApp3.Classes.Games
{
    internal class Chess : Game
    {
        public Chess(Player player1, Player player2) : base(player1, player2)
        {
            _name = "Chess";
        }
        [JsonConstructor]
        public Chess(int id, int firstPlayerId, int secondPlayerId, bool isFinished, int? winnerId, int? loserId)
            : base(id, firstPlayerId, secondPlayerId, isFinished, winnerId, loserId) { }
    }
}
