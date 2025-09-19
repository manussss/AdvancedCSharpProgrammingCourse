namespace AdvancedCSharpProgrammingCourse.ConsoleApp;

public class Program
{
    private static void Main(string[] args)
    {
        Calculate calculate = Add;
        var result = calculate(1, 1);

        Console.WriteLine($"The result is: {result}");
    }

    static double Add(double a, double b) => a + b;
}

delegate double Calculate(double x, double y);