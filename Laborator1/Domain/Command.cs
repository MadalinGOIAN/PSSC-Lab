using System.Text;

namespace Laborator1.Domain;

public record Command
{
    public Person Person { get; set; }
    public List<Product> ProductsList { get; set; }

    public override string ToString()
    {
        StringBuilder tmp = new StringBuilder(Person.ToString() + "\n\nComanda:");

        foreach (Product p in ProductsList)
            tmp.Append("\n" + p.ToString());

        return tmp.ToString();
    }
}
