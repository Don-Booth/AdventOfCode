namespace Day1;

internal class Program
{
    static void Main(string[] args)
    {
        int grandTotalPartOne = PartOne.GetPartOneAnswer("input.txt");
        int grandTotalPartTwo = PartTwo.GetPartTwoAnswer("input.txt");
        char resultPartOne = ' ';
        char resultPartTwo = ' ';

        if (grandTotalPartOne == 53194) resultPartOne = 'X';
        if (grandTotalPartTwo == 54249) resultPartTwo = 'X';

        Console.WriteLine($@"[{resultPartOne}] The grand total for Part One is : {grandTotalPartOne}");
        Console.WriteLine($@"[{resultPartTwo}] The grand total for Part Two is : {grandTotalPartTwo}");
    }
}