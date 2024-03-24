namespace StackApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackDoubles();
            StackStrings();

            Console.ReadLine();
        }

        public static void StackDoubles()
        {
            var stackapp = new SimpleStack<double>();
            stackapp.push(1.2);
            stackapp.push(2.8);
            stackapp.push(3.0);

            double sum = 0.0;

            while (stackapp.Count > 0)
            {
                double item = stackapp.pop();
                Console.WriteLine($"Item: {item}");
                sum += item;
            }

            Console.WriteLine($"Sum: {sum}");
        }

        private static void StackStrings()
        {
            var stackapp = new SimpleStack<string>();
            stackapp.push("Wired Brain Coffee");
            stackapp.push("Pluralsight");

            while (stackapp.Count > 0)
            {
                Console.WriteLine(stackapp.pop());
            }
        }
    }
}