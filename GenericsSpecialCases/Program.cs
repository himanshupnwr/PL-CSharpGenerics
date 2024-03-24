namespace GenericsSpecialCases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _ = new Container<string>();
            _ = new Container<string>();
            var container = new Container<int>();

            Console.WriteLine($"Container<string>: {Container<string>.InstanceCount}");
            Console.WriteLine($"Container<int>: {Container<int>.InstanceCount}");
            Console.WriteLine($"Container<bool>: {Container<bool>.InstanceCount}");
            Console.WriteLine($"ContainerBase: {ContainerBase.InstanceCountBase}");

            container.PrintItem("Hello from generic method in generic class");

            var result = Add(2, 3);
            Console.WriteLine($"2+3={result}");

            var result2 = Add(2.7, 3.3);
            Console.WriteLine($"2.7+3.3={result2}");

            Console.ReadLine();
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }

        private static double Add(double x, double y)
        {
            return x + y;
        }
    }

    class ContainerBase
    {
        public ContainerBase() => InstanceCountBase++;

        public static int InstanceCountBase { get; private set; }
    }

    class Container<T> : ContainerBase
    {
        public Container() => InstanceCount++;

        public static int InstanceCount { get; private set; }

        public void PrintItem<TItem>(TItem item)
        {
            Console.WriteLine($"Item: {item}");
        }
    }
}
