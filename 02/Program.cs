namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../input.txt");
            int score = 0;

            foreach(string line in input)
            {
                Hand hand = new(line.Split(" "));
                int point = hand.Play();
                score += point;
            }

            Console.WriteLine(score);
        }
    }

    public enum Choice
    {
        Rock = 1,       // A - X
        Paper = 2,      // B - Y
        Scissors = 3    // C - Z
    }
}
