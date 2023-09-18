using Newtonsoft.Json;
using System.Collections.Generic;
using WpfApp3.Classes.Storages;
using WpfApp3.Storages;

namespace WpfApp3
{
    public class Player
    {
        private int _id;
        public int Id => _id;

        private string _login;
        public string Login => _login;

        private int _played;
        public int PlayedGames => _played;

        private int _wins;
        public int Wins => _wins;

        private int _losses;
        public int Losses => _losses;

        private int _draws;
        public int Draws => _draws;

        private List<Game> _history;
        [JsonIgnore]
        public List<Game> History => _history;

        private GameQueue _queue;
        [JsonIgnore]
        public GameQueue Queue => _queue;

        [JsonIgnore]
        public string DisplayInList => $"ID{_id}: {_login}; всего игр: {_played}, победы/поражения/ничьи: {_wins}/{_losses}/{_draws}";

        public Player(string login) 
        {
            (_id, _login, _queue, _history) = (PlayerStorage.PlayersList.Count + 1, login, new(this), new());
            PlayerStorage.Add(this);
            PlayerStorage.Save();
        }
        [JsonConstructor]
        public Player(int id, string login, int playedGames, int wins, int losses, int draws)
        {
            _id = id;
            _login = login;
            _played = playedGames;
            _wins = wins;
            _losses = losses;
            _draws = draws;
            _history = new();
            _queue = new(this);
            PlayerStorage.Add(this);
        }

        public override string ToString() => $"{_login}:{_id}" ?? "null:null";

        public void PlanGame(Game game) // добавить игру в конец очереди
        {
            _queue.Add(game);
        }

        public void UnplanGame(Game game) // убрать игру из очереди
        {
            _queue.Delete(game);
        }

        public void Play(Game game) // играть вне очереди
        {
            if (_queue.Games.Contains(game))
            {
                game.FinishGame();
            }
        }
        public void Play() // играть в первую игру в очереди
        {
            if (Queue.Games.Count > 0)
            {
                Queue.Games[0].FinishGame();
            }
        }
        public void Win()
        {
            _wins++;
            _played++;
        }
        public void Lose()
        {
            _losses++;
            _played++;
        }
        public void Draw()
        {
            _draws++;
            _played++;
        }
    }
}
