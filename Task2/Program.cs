namespace Task2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Task2: ");
            var result1 = CalculatePower(2, 3);
            Console.WriteLine($"2^3 = {result1}");

            CalculateParallelAsync(4, 2);
            Console.WriteLine($"4^2 = {result1}");

            CalculateExpressionAsync(2, 3, 4, 2, 5, 3, 1, 4);

            Console.ReadLine();
        }
        static long CalculatePower(int a, int x)
        {
            long result = 1;
            for (int i = 0; i < x; i++)
            {
                result *= a;
            }
            return result;
        }
        static async void CalculateParallelAsync(int a, int x)
        {
            await Task.Run(() =>
            {
                long result = CalculatePower(a, x);
                Console.WriteLine($"{a}^{x} = {result} (вызов через параллельный асинхронный метод)");
            });
        }

        static async void CalculateExpressionAsync(int a1, int x1, int a2, int x2, int a3, int x3, int a4, int x4)
        {
            await Task.Run(() =>
            {
                var result1 = CalculatePower(a1, x1);
                var result2 = CalculatePower(a2, x2);
                var result3 = CalculatePower(a3, x3);
                var result4 = CalculatePower(a4, x4);

                if (result3 == 0 || result4 == 0)
                {
                    Console.WriteLine("Деление на 0 нельзя");
                    return;
                }
                double finalResult = (double)(result1 + result2) / (result3 - result4);
                Console.WriteLine($"(a1^x1+a2^x2)/(a3^x3-a4^x4) = {finalResult}");
            });
        }
    }
}
