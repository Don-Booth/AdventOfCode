using Day2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Part2 : Part1
    {
        public static int GetSumOfPowers(List<Game2> games)
        {
            int result = 0;

            foreach (Game2 game in games)
            {
                result += game.Power;
            }

            return result;
        }

        public static new List<Game2> LoadGamesIntoList(string fileName, BagMaximums bagMaximums)
        {
            List<Game2> result = new();

            foreach (string line in File.ReadLines(fileName))
            {
                Game2 game = new Game2();

                game.GameID = int.Parse(line.Substring(line.IndexOf(' ', 0), line.IndexOf(':') - line.IndexOf(' ', 0)));

                string linesubsets = line.Substring(line.IndexOf(":") + 2);

                foreach (string subset in linesubsets.Split(';'))
                {
                    Subset subsetToLoadToGame = new();

                    foreach (string set in subset.Trim().Split(","))
                    {
                        var setArray = set.Trim().Split(" ");
                        int count = int.Parse((string)setArray[0]);

                        switch (setArray[1])
                        {
                            case "red":
                                subsetToLoadToGame.RedCount = count;
                                break;
                            case "green":
                                subsetToLoadToGame.GreenCount = count;
                                break;
                            case "blue":
                                subsetToLoadToGame.BlueCount = count;
                                break;
                        }
                    }

                    game.Subsets.Add(subsetToLoadToGame);
                }

                foreach (Subset subsetBagMaxCheck in game.Subsets)
                {
                    if (subsetBagMaxCheck.RedCount > bagMaximums.MaxRed || subsetBagMaxCheck.GreenCount > bagMaximums.MaxGreen || subsetBagMaxCheck.BlueCount > bagMaximums.MaxBlue)
                    {
                        game.Possibility = false;
                        break;
                    }
                }

                game.CalculatePower();

                result.Add(game);
            }

            return result;
        }
    }
}
