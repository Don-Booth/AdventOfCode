namespace Day3.Model;

internal class PartMap
{
    public char[,] Map {  get; set; }
    public int MapWidth { get; set; }
    public int MapHeight { get; set; }

    public PartMap(char[,] map, int mapWidth, int mapHeight)
    {
        MapWidth = mapWidth;
        MapHeight = mapHeight;
        Map = new char[mapWidth, mapHeight];
        Map = map;
    }
}
