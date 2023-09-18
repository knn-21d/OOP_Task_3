using Newtonsoft.Json;
using System.Collections.Generic;

namespace WpfApp3.Storages
{
    public class GameQueue
    {
        private Player _player;
        private List<Game> _games;
        [JsonIgnore]
        public List<Game> Games => _games;
        public void Add(Game game) => _games.Add(game);
        public void Delete(Game game)
        {
            _games.Remove(game);
            game.EnsureRemoved();
        }

        public GameQueue(Player player)
        {
            _games = new();
            _player = player;
        }
    }
}