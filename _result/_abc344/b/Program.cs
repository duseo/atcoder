using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input;
        while((input = int.Parse(Console.ReadLine() ?? string.Empty)) != 0) {
            numbers.Add(input);
        }
        numbers.Add(0);
        numbers.Reverse();
        foreach(int number in numbers) {
            Console.WriteLine(number);
        }
    }
}
