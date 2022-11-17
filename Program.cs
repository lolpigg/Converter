using System.IO;
namespace convert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Доброго времени суток! Введите путь до файла:");
            Random random = new Random();
            int intrnd = random.Next(50);
            if (intrnd == 44)
            {
                Console.WriteLine("Скорогудаева ван лав (это типо пасхалка) ^_^");
            }
            Read.Reading();
        }
    }
}