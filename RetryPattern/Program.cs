using System;

namespace RetryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Se inicia el ejemplo");

            var service = new CocktailService();
            var res = Retry.Do(() => service.GetRandomCocktail());
        }
    }
}
