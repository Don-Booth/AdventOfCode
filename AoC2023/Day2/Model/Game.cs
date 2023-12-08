namespace Day2.Model
{
    internal class Game
    {
        public int GameID { get; set; }
        public bool Possibility {  get; set; }
        public List<Subset> Subsets { get; set; }

        public Game()
        {
            GameID = 0;
            Possibility = true;
            Subsets = new List<Subset>();
        }
    }
}
