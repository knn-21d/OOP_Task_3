using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp3.Classes.Games;
using WpfApp3.Classes.Storages;

namespace WpfApp3
{
    internal static class RandomizedTest
    {
        public static void Test(int playersCount, int gamesCount)
        {
            Random rnd = new();
            const string chars = "abcdefghigklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomLogin;
            for (int i = 0; i < playersCount; i++)
            {
                randomLogin = new string(Enumerable.Repeat(chars, rnd.Next(5, 30))
                    .Select(s => s[rnd.Next(s.Length)]).ToArray());
                new Player(randomLogin);
            }
            List<Player> list = new(PlayerStorage.PlayersList);
            for (int i = 0; i < gamesCount; i++)
            {
                Player player1 = list[rnd.Next(0, list.Count - 1)];
                list.Remove(player1);
                Player player2 = list[rnd.Next(0, list.Count - 1)];
                list.Add(player1);
                switch (rnd.Next(1, 5))
                {
                    case 1:
                        new Backgammon(player1, player2).FinishGame();
                        break;
                    case 2:
                        new Checkers(player1, player2).FinishGame();
                        break;
                    case 3:
                        new Chess(player1, player2).FinishGame();
                        break;
                    case 4:
                        new Dominoes(player1, player2).FinishGame();
                        break;
                    case 5:
                        new Monopoly(player1, player2).FinishGame();
                        break;
                }
            }
        }
    }
}
