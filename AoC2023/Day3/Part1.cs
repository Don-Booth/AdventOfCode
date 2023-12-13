using AoCUtils.Files;
using Day3.Model;

namespace Day3;

internal class Part1
{
    public static int GetEnginePartsSum(string fileName)
    {
        int result = 0;
        PartMap partMap = GetCharMapFromStringList(fileName);
        List<MachinePart> machineParts = new();
        string partNumber = String.Empty;

        for(int x = 0; x < partMap.MapHeight; x++)
        { // main pointer, going row to row
            for(int y = 0; y < partMap.MapWidth; y++)
            { // main pointer, going column to column

                if (Char.IsDigit(partMap.Map[x, y])) partNumber += partMap.Map[x, y];
                else if (partNumber.Length > 0)
                { // we've found our partNumber
                    MachinePart part = new MachinePart();
                    part.PartNumber = int.Parse(partNumber);
                    // need to check around the perimeter of the thing here to validate if it's a genuine part.

                    // across and down
                    int searchRow = (x - 1) < 0 ? x : x - 1;
                    int searchCol = 0;

                    if (searchRow == x) searchCol = y;
                    else searchCol = (y - partNumber.Length - 1) < 0 ? 0 : y - partNumber.Length - 1;
                    
                    for(; searchCol <= y; searchCol++)
                    {
                        if (partMap.Map[searchRow, searchCol] != '.')
                        {
                            part.IsAGenuinePart = true;
                            break;
                        }
                    }

                    if (partMap.Map[x, y] != '.') part.IsAGenuinePart = true;

                    // back and up
                    if (!part.IsAGenuinePart)
                    {
                        searchRow = (x + 1) > partMap.MapHeight - 1 ? x : x + 1;
                        if (searchRow > x) searchCol = y;
                        else searchCol = y - partNumber.Length - 1;

                        for (; searchCol >= (y - partNumber.Length - 1) && searchCol >= 0; searchCol--)
                        {
                            if (partMap.Map[searchRow, searchCol] != '.')
                            {
                                part.IsAGenuinePart = true;
                                break;
                            }
                        }

                        if ((y - partNumber.Length - 1) >= 0 && (partMap.Map[x, (y - partNumber.Length - 1)] != '.')) part.IsAGenuinePart = true;
                    }

                    machineParts.Add(part);
                    partNumber = string.Empty;
                }
            }
        }

        foreach(MachinePart machinePart in machineParts)
        {
            if (machinePart.IsAGenuinePart) result += machinePart.PartNumber;
        }

        using (StreamWriter outputFile = new StreamWriter(@"D:\resultstest.txt"))
        {
            foreach (MachinePart machinePart in machineParts)
            {
                if (!machinePart.IsAGenuinePart)
                    outputFile.WriteLine($@"{machinePart.PartNumber}");
            }
        }
    
        return result;
    }

    private static PartMap GetCharMapFromStringList(string fileName)
    {
        int mapCols = 0;
        int mapRows = 0;
        List<string> fileRows = new();

        fileRows = TextFiles.LoadTextFileToStringList(fileName);

        mapCols = fileRows[0].Length;
        mapRows = fileRows.Count;
        char[,] map = new char[mapCols, mapRows];

        for (int i = 0; i < mapRows; i++)
        {
            string strRow = fileRows[i];

            for (int j = 0; j < mapCols; j++)
            {
                map[i, j] = strRow[j];
            }
        }

        PartMap partMap = new PartMap(map, mapCols, mapRows);

        return partMap;
    }
}
