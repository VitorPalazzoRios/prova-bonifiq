namespace ProvaPub.Services
{
	public class RandomService
	{
        private readonly Random _random;

        public RandomService()
        {

            // Criando uma unica instancia 
            _random = new Random(Guid.NewGuid().GetHashCode());
        }

        public int GetRandom()
        {        
            //Usando a mesma para que o numero gerado seja realmente aleatorio
            return _random.Next(100);
        }

    }
}
