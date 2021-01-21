using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RetryPattern
{
    public class CocktailService
    {
        public string GetRandomCocktail()
        {
            //Se simula un error
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var value = random.Next(0, 5);

            if(value < 2)
            {
                throw new Exception("Error en el servicio");
            }

            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/random.php").Result;
            return response.Content.ReadAsStringAsync().Result;
          
        }
    }
}
