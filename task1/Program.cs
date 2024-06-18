namespace task1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Task1: ");
            await ShowDegreeAsync(2, 4);
            await ShowDegreeAsync(5, 3);
            await ShowDegreeAsync(4, 1);
            await ShowDegreeAsync(5, 2);

            await ShowDegreeParalleAsync(4, 3);
            await ShowDegreeParalleAsync(2, 5);
            await ShowDegreeParalleAsync(4, 6);
            await ShowDegreeParalleAsync(1, 4);

        }

        static async Task<long> ShowDegreeAsync(int a, int x)
        {
            await Task.Run(() =>
            {
                int result = 1;
                for (int i = 0; i < x; i++)
                {
                    result *= a;
                }
                Console.WriteLine($"{a}^{x}={result}");
            });
            return 0;
        }

        static async Task ShowDegreeParalleAsync(int a, int x)
        {
            await Task.Run(async () =>
            {
                int result = 1;
                Parallel.For(0, x, i =>
                {
                    result *= a;
                });
                Console.WriteLine($"{a}^{x} = {result}");
            });
        }
    }
}
