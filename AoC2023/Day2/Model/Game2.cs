using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Model
{
    internal class Game2 : Game
    {
        public int Power {  get; set; }

        public Subset MinPieces { get; set; }

        public Game2()
        {
            Power = 0;
            MinPieces = new Subset();
            MinPieces.RedCount = 0;
            MinPieces.GreenCount = 0;
            MinPieces.BlueCount = 0;
        }

        public void CalculatePower()
        {
            foreach (Subset subsetGame in Subsets)
            {
                if (subsetGame.RedCount > MinPieces.RedCount) MinPieces.RedCount = subsetGame.RedCount;
                if (subsetGame.GreenCount > MinPieces.GreenCount) MinPieces.GreenCount = subsetGame.GreenCount;
                if (subsetGame .BlueCount > MinPieces.BlueCount) MinPieces.BlueCount = subsetGame.BlueCount;
            }

            Power = MinPieces.RedCount * MinPieces.GreenCount * MinPieces.BlueCount;
        }
    }
}
