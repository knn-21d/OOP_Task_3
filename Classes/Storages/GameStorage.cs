using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WpfApp3.Classes.Storages
{
    public static class GameStorage
    {
        private static List<Game> _games;
        public static List<Game> GamesList { get => _games; }
        static GameStorage() => _games = new();

        public static void Add(Game game) => _games.Add(game);
        public static void Delete(Game game) => _games.Remove(game);

        public static void Save()
        {
            string path = @"GamesStorageExternal.json";
            string json = JsonConvert.SerializeObject(_games, Formatting.Indented,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            File.WriteAllText(path, json);
        }
        public static void Load()
        {
            if (!File.Exists(@"GamesStorageExternal.json") ||
                String.IsNullOrEmpty(File.ReadAllText(@"GamesStorageExternal.json")))
            {
                return;
            }
            string json = File.ReadAllText(@"GamesStorageExternal.json");
            List<Game>? loaded = JsonConvert.DeserializeObject<List<Game>>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            _games = loaded ?? new();

            foreach (Game g in _games)
            {
                if (g.IsFinished)
                {
                    g.Player1.History.Add(g);
                    g.Player2.History.Add(g);
                }
                else
                {
                    g.Player1.Queue.Add(g);
                    g.Player2.Queue.Add(g);
                }
            }
        }
    }
}
