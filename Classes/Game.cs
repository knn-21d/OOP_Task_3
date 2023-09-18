using Newtonsoft.Json;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfApp3.Classes.Storages;

namespace WpfApp3
{
    public abstract class Game
    {
        protected string _name = "";
        private readonly int _id;
        private readonly Player _player1;
        private readonly Player _player2;

        public string Name => _name;
        public int Id => _id;

        [JsonIgnore]
        public Player Player1 => _player1;
        public int FirstPlayerId => _player1.Id;

        [JsonIgnore]
        public Player Player2 => _player2;
        public int SecondPlayerId => _player2.Id;

        public bool IsFinished { get; set; }

        [JsonIgnore]
        public Player? Winner { get; set; }
        public int? WinnerId => Winner?.Id;

        [JsonIgnore]
        public Player? Loser { get; set; }
        public int? LoserId => Loser?.Id;

        [JsonIgnore]
        public virtual bool IsDrawn => IsFinished && Winner is null && Loser is null;

        [JsonIgnore]
        public string DisplayInList
        {
            get
            {
                string name = GetType().Name;
                if (!IsFinished)
                {
                    return $"{name} {Player1.Login} vs {Player2.Login}";
                }
                else if (IsDrawn)
                {
                    return $"{name} {Player1.Login} vs {Player2.Login}: ничья";
                }
                else
                {
                    return $"{name} {Player1.Login} vs {Player2.Login}: победа {Winner?.Login}";
                }
            }
        }

        public Game(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
            _id = GameStorage.GamesList.Count() + 1;
            GameStorage.Add(this);
            PlayerStorage.Save();
        }
        [JsonConstructor]
        public Game(int id, int firstPlayerId, int secondPlayerId, bool isFinished, int? winnerId, int? loserId)
        {
            _id = id;
            _player1 = PlayerStorage.PlayersList.First(p => p.Id == firstPlayerId);
            _player2 = PlayerStorage.PlayersList.First(p => p.Id == secondPlayerId);
            IsFinished = isFinished;
            Winner = winnerId is null ? null : PlayerStorage.PlayersList.First(p => p.Id == winnerId);
            Loser = loserId is null ? null : PlayerStorage.PlayersList.First(p => p.Id == loserId);
        }

        public virtual void FinishGame()
        {
            if (IsFinished) return;
            Random rnd = new();
            int roll = rnd.Next(0, 100);
            if (roll == 0)
            {
                Player1.Draw();
                Player2.Draw();
            }
            else if (roll < 51)
            {
                Winner = Player1;
                Player1.Win();
                Loser = Player2;
                Player2.Lose();
            }
            else
            {
                Winner = Player2;
                Player2.Win();
                Loser = Player1;
                Player1.Lose();
            }
            IsFinished = true;
            Player1.History.Add(this);
            Player1.Queue.Delete(this);
            Player2.History.Add(this);
            Player2.Queue.Delete(this);
        }
        public void EnsureRemoved()
        {
            if (Player1.Queue.Games.Contains(this))
            {
                Player1.Queue.Delete(this);
            }
            if (Player2.Queue.Games.Contains(this))
            {
                Player2.Queue.Delete(this);
            }
            PlayerStorage.Save();
        }
    }
}
