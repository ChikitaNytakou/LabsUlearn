namespace Percentage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите через пробел:" +
                "- сумму, которую вы хотите положить в банк" +
                "- годовую процентную ставку" +
                "- на какое количество месяцев");
            string userInp = Console.ReadLine();
            Console.WriteLine(Calculate(userInp));
        }

        public static double Calculate(string userInput)
        {
            string[] userInputNumbers = userInput.Split(' ');
            double amount = double.Parse(userInputNumbers[0]);
            double bid = double.Parse(userInputNumbers[1]);
            double month = double.Parse(userInputNumbers[2]);
            return amount * Math.Pow((1 + bid / (12 * 100)), month);
        }
    }
}
