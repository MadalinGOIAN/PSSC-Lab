using Laborator1.Domain;
using static Laborator1.Domain.Quantity;

internal class Program
{
    private static Person person = new Person()
    {
        Name = "Ion",
        Surname = "Popescu",
        PhoneNumber = "0770222222",
        Address = "Romania"
    };
    private static List<Product> products = new List<Product>();
    private static Command command = new Command();
    private static byte option = 0;

    private static void Main(string[] args)
    {
        Console.WriteLine("1. Creare comanda");
        Console.WriteLine("2. Iesire");

        Console.Write("\nIntroduceti optiunea: ");
        option = Convert.ToByte(Console.ReadLine());

        Console.Clear();

        if (option == 1)
        {
            do
            {
                Console.WriteLine("1. Adaugare produs");
                Console.WriteLine("2. Vizualizare comanda");
                Console.WriteLine("3. Finalizare comanda");

                Console.Write("\nIntroduceti optiunea: ");
                option = Convert.ToByte(Console.ReadLine());

                Console.Clear();

                if (option == 1)
                {
                    Console.Write("Cod produs: ");
                    string? code = Console.ReadLine();
                    
                    Console.Write("Cantitate: ");
                    string quantity = Console.ReadLine();

                    products.Add(new Product() 
                        { 
                            Code = code,
                            Quantity = ConvertToQuantity(quantity)
                        });

                    Console.Clear();
                }
                else if (option == 2)
                {
                    if (products.Count == 0)
                    {
                        Console.WriteLine("Nu a fost introdus niciun produs");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else foreach (Product p in products)
                            Console.WriteLine(p.ToString());

                    Console.ReadLine();
                    Console.Clear();
                }
            } while (option != 3);

            products.RemoveAll(p => p.Quantity.GetType().Name.Equals("Undefined"));
            command = new Command()
            {
                Person = person,
                ProductsList = products
            };
        }

        Console.WriteLine("1. Vizualizare comanda");
        Console.WriteLine("2. Iesire");

        Console.Write("\nIntroduceti optiunea: ");
        option = Convert.ToByte(Console.ReadLine());

        Console.Clear();

        if (option == 1)
        {
            Console.WriteLine(command.ToString());
            Console.ReadLine();
            Console.Clear();
        }
    }
}