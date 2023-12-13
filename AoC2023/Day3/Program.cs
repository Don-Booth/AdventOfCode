namespace Day3;

internal class Program
{
    static void Main(string[] args)
    {
        //int result = Part1.GetEnginePartsSum(@"Data\testinput.txt"); // answer is 4361
        int result = Part1.GetEnginePartsSum(@"Data\input.txt");
        // answer is 538224 (THIS IS TOO LOW) - the real number should probably be 539680

        //Currently I get 540765 which is too high
        Console.WriteLine($@"The Part Sum is : {result}");
    }
}
