namespace AoCUtils.Files;

public static class TextFiles
{
    public static List<string> LoadTextFileToStringList(string textFile)
    {
        List<string> result = new();

        foreach (string line in File.ReadLines(textFile))
        {
            result.Add(line);
        }

        return result;
    }
}
