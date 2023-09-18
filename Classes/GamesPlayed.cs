using System.Collections.Generic;
using System.Linq;
using WpfApp3.Classes.Storages;

namespace WpfApp3.Classes
{
    internal class GamesPlayed
    {
        public string Name { get; set; }
        public int Played { get; set; }
        public GamesPlayed(string name, int played)
        {
            Name = name;
            Played = played;
        }

        public static List<GamesPlayed> RatingList
        {
            get
            {
                List<string> names = new();
                List<int> times = new();
                List<GamesPlayed> list = new();
                for (int i = 0; i < GameStorage.GamesList.Count; i++)
                {
                    if (!names.Contains(GameStorage.GamesList[i].GetType().Name))
                    {
                        names.Add(GameStorage.GamesList[i].GetType().Name);
                        times.Add(1);
                    }
                    else
                    {
                        times[names.FindIndex(0, names.Count, n => n == GameStorage.GamesList[i].GetType().Name)]++;
                    }
                }
                for (int i = 0; i < names.Count; i++)
                {
                    list.Add(new(names[i], times[i]));
                }
                return list;
            }
        }
    }
}