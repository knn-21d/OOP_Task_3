using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Serialization;

namespace WpfApp3.Classes.Storages
{
    public static class PlayerStorage
    {
        private static List<Player> _players;

        static PlayerStorage() => _players = new();

        public static List<Player> PlayersList { get => _players; }
        public static List<Player> SortByPlayed { get => _players.OrderBy(p => p.PlayedGames).ToList(); }
        public static List<Player> SortByWins { get => _players.OrderBy(p => p.Wins).ToList(); }

        public static void Add(Player player) => _players.Add(player);
        public static void Delete(Player player) => _players.Remove(player);
        public static void Save()
        {
            string path = @"PlayersStorageExternal.json";
            string json = JsonConvert.SerializeObject(_players, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            File.WriteAllText(path, json);
            GameStorage.Save();
        }
        public static void Load()
        {
            if (!File.Exists(@"PlayersStorageExternal.json") || 
                String.IsNullOrEmpty(File.ReadAllText(@"PlayersStorageExternal.json"))) return;

            string json = File.ReadAllText(@"PlayersStorageExternal.json");
            List<Player>? loaded = JsonConvert.DeserializeObject<List<Player>>(json);
            _players = loaded ?? new();

            GameStorage.Load();
        }
    }
}
