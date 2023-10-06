namespace Laborator1.Domain;

public record Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return $"Nume: {Name}\n" +
               $"Prenume: {Surname}\n" +
               $"Numar de telefon: {PhoneNumber}\n" +
               $"Adresa: {Address}";               
    }
}
